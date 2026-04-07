public interface IInteractable {
    void Interact();
    void OnInRange() { }

    void OnOutOfRange() { }
}