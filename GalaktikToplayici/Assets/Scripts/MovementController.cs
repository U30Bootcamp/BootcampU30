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
    private bool isFalling;
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
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
            isFalling = true;
        }
    }

    // normale göre 1.5 kat ve yerden daha yukarıdayken zıplar
    private void Jump()
    {
        bool raycastHit = Physics.Raycast(transform.position, Vector3.down, 3.01f);

        // eğer karakter yerde ise zıplat
        if (raycastHit && isFalling)
        {
            isFalling = false;
            float jumpForce = Mathf.Sqrt(jumpHeight * jumpHeight * Physics.gravity.y * -2f) * _playerRigidbody.mass * 1.5f;
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void MoveJump()
    {
        bool raycastHit = Physics.Raycast(transform.position, Vector3.down, 1.01f);

        // eğer karakter yerde ise zıplat
        if (raycastHit && isFalling)
        {
            isFalling = false;
            float jumpForce = Mathf.Sqrt(jumpHeight * jumpHeight * Physics.gravity.y * -2f) * _playerRigidbody.mass;
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        Vector3 currentVelocity = _playerRigidbody.velocity;
        Vector3 targetVelocity = new Vector3(direction.x, 0, direction.y) * moveSpeed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - currentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z); // karakterin düşebilmesi için gerekli
        Vector3.ClampMagnitude(velocityChange, maxForce);
        
        _playerRigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        MoveJump(); // astronot yürüyüşü için zımplama ekler
    }
}
