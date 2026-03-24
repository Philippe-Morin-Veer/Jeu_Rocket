using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovvement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _maxForceParSeconde =500f;
    private Vector2 _moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(new Vector3(_moveDirection.x*_maxForceParSeconde,0,_moveDirection.y*_maxForceParSeconde)* Time.fixedDeltaTime);
    }
     void OnMove(InputValue inputValue)
    {
        _moveDirection = inputValue.Get<Vector2>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Collison");
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        }
}
