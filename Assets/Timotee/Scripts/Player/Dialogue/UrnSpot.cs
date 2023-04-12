using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UrnSpot : MonoBehaviour, IInteractable
{
    public List<Item> UrnItems;
    public List<GameObject> Urns;

    public Animator[] FirstDoors;
    public Animator LastDoor;
    public GameObject GameObject => gameObject;
    public bool Interact(IActor user)
    {
        bool removedUrn = false;

        for (int x = 0; x < Urns.Count; x++)
        {
            Item item = UrnItems[x];
            UnityEngine.GameObject urn = Urns[x];
            
            if (user.Inventory.ContainItem(item))
            {
                user.Inventory.RemoveItem(item);
                urn.SetActive(true);
                Urns.Remove(urn);
                UrnItems.Remove(item);
                removedUrn = true;
            }
        }

        if (removedUrn && Urns.Count == 2) {
            foreach (var door in FirstDoors)
                door.Play("Open");
        }

        if (removedUrn && Urns.Count == 0)
            LastDoor.Play("Open");

        return false;
    }
}