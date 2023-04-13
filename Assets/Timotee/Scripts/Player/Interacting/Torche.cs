using UnityEngine;
using UnityEngine.VFX;

public class Torche : MonoBehaviour, IInteractable
{
    public Item Lighter;

    public Light SpotLight;
    public VisualEffect Flames;

    public GameObject GameObject => gameObject;
    public bool Interact(IActor user)
    {
        if (!user.Inventory.ContainItem(Lighter)) return false;
        
        Flames.gameObject.SetActive(true);
        SpotLight.gameObject.SetActive(true);
        return true;
    }
}