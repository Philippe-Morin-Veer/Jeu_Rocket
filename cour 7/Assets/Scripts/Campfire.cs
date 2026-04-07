using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable {
    private Canvas _canvas;
    private ParticleSystem _particles;
    void Start() {
        _particles= GetComponentInChildren<ParticleSystem>();
        _canvas = GetComponentInChildren<Canvas>();
        _canvas.enabled = false;
    }

    public void OnInRange() {
        _canvas.enabled = true;
    }

    public void OnOutOfRange() {
        _canvas.enabled = false;
    }

    public void Interact() {
        if (_particles.isPlaying)
        {
            _particles.Stop();
        }
        else
        {
            _particles.Play();
        }
    }
}
