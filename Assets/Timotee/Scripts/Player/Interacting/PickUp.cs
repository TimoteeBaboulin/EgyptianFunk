using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable{
    public GameObject GameObject => gameObject;
    [SerializeField] private Item _item;

    /// <returns>Return whether or not the gameobject was destroyed (true if it is destroyed)</returns>
    public bool Interact(IActor user){
        user.Inventory.AddItem(_item);
        Destroy(gameObject);
        return true;
    }
}
