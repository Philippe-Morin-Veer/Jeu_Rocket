using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _inputMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       _rb.MovePosition(_rb.position+_inputMovement*Time.fixedDeltaTime); 
    }
    void OnMove(InputValue inputValue)
    {
        _inputMovement = inputValue.Get<Vector2>();
    }

    }
