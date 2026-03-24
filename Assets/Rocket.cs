using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class Rocket : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveDirection;
    [SerializeField] private float _forceBooster = 5000f;
    private bool _isThrusting = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_isThrusting)
        {
            _rb.AddRelativeForce(new Vector3(0,1,0) * _forceBooster * Time.fixedDeltaTime);
        }
        if (_moveDirection.x != 0)
        {
            _rb.AddRelativeTorque(new Vector3() * _rotationInput * _rotationForce * Time.fixedDeltaTime);
        }
        _rb.AddRelativeForce(new Vector3())
    }

    private void OnJump(InputValue inputValue )
    {
        _isThrusting = inputValue.isPressed;
    }
    private void OnMove(InputValue inputValue)
    {
        _moveDirection = inputValue.Get<Vector2>();
    }
}
