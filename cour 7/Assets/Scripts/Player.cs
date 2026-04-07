using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    private Rigidbody _rb;
    private Vector2 _input = Vector2.zero;
    [SerializeField] private float _speed = 3333f;

    private List<IInteractable> _interactables = new List<IInteractable>();

    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }

    private void Move() {
        _rb.AddForce(new Vector3(_input.x, 0, _input.y)  * _speed * Time.fixedDeltaTime, ForceMode.Force);
    }

    void OnMove(InputValue value) {
        _input = value.Get<Vector2>();
    }

    void OnInteract() {
        _interactables.ForEach(interactable => interactable.Interact());
    }

    void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IInteractable interactable)) {
            _interactables.Add(interactable);
            interactable.OnInRange();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.TryGetComponent(out IInteractable interactable)) {
            _interactables.Remove(interactable);
            interactable.OnOutOfRange();
        }
    }
}
