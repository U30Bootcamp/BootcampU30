using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody _playerRigidbody;
    private Vector2 _mMove;
    
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

        // Fix float jump, increase speed when falling down
        if (_playerRigidbody.velocity.y < 0f)
        {
            _playerRigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.deltaTime;
        }
    }
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
    private void Jump()
    {
        // if (IsGrounded())
        {
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // Rotate direction according to world Y rotation of player.
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
        
        // Fix mevlana 
        Spin();
    }

    private void Spin()
    {
        Vector3 rotationVelocity = _playerRigidbody.velocity;
        rotationVelocity.y = 0f;

        if (rotationVelocity.sqrMagnitude < 0.01f)
        {
            _playerRigidbody.angularVelocity = Vector3.zero;
        }
        else
        {
            _playerRigidbody.rotation = Quaternion.LookRotation(rotationVelocity, Vector3.up);
        }
    }
}
