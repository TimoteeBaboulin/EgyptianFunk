using UnityEngine;

public interface IInteractable{
    public GameObject GameObject{ get; }

    public bool Interact(IActor user);
}