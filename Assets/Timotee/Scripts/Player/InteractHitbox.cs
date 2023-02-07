using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractHitbox : MonoBehaviour{
    public List<IInteractable> Interactables => _interactables;
    private List<IInteractable> _interactables = new();

    public IInteractable Selected => _selected;
    private IInteractable _selected;

    private void OnTriggerEnter(Collider other){
        var interactable = other.GetComponent<IInteractable>();
        
        if (interactable == null) return;

        Selected.GameObject.layer = LayerMask.NameToLayer("Interactable");
        _interactables.Add(interactable);
    }
    
    private void OnTriggerExit(Collider other){
        var interactable = other.GetComponent<IInteractable>();
        
        if (interactable != null)
            _interactables.Remove(interactable);
    }
}