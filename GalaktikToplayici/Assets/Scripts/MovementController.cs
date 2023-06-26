using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxForce;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float fallRate;
    
    private Rigidbody _playerRigidbody;
    private Vector2 _mMove;
    private bool _isFalling;
    private bool _isDead;
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump(3.01f, 1.5f);
        }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _mMove = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(_mMove);

        // karakter düşerken süzülme hızını değiştirir
        if (_playerRigidbody.velocity.y < 0f)
        {
            _playerRigidbody.AddForce(Vector3.down * fallRate);
            _isFalling = true;
        }
    }

    private void Jump(float maxHeightFromObject, float jumpScale)
    {
        if (_isDead)
            return;
        
        bool raycastHit = ShootRaycast(maxHeightFromObject);

        // eğer karakter yerde ise zıplat
        if (raycastHit && _isFalling)
        {
            _isFalling = false;
            float jumpForce = Mathf.Sqrt(jumpHeight * jumpHeight * Physics.gravity.y * -2f) * _playerRigidbody.mass * jumpScale;
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void Move(Vector2 direction)
    {
        if (_isDead)
            return;    

        if (direction == Vector2.zero)
            return;

        Vector3 currentVelocity = _playerRigidbody.velocity;
        Vector3 targetVelocity = new Vector3(direction.x, 0, direction.y) * moveSpeed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - currentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z); // karakterin düşebilmesi için gerekli
        Vector3.ClampMagnitude(velocityChange, maxForce);
        
        _playerRigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        Jump(1.01f, 1f); // astronot yürüyüşü için zıplama ekler
    }

    private bool ShootRaycast(float maxHeightFromObject)
    {
        bool raycastHit = Physics.Raycast(transform.position, Vector3.down, maxHeightFromObject);
        return raycastHit;
    }

    private void GameOver()
    {
        Debug.Log("game over UI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            _isDead = true;
            _playerRigidbody.AddForce(Vector3.back * 10f, ForceMode.Impulse);
            GameOver();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("FallLimit"))
        {
            _isDead = true;
            GameOver();
        }
    }
}
