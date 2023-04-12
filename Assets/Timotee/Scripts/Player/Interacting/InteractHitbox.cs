using System;
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
        
        if (_selected != null)
            _selected.GameObject.layer = LayerMask.NameToLayer("Default");

        _selected = interactable;
        Selected.GameObject.layer = LayerMask.NameToLayer("Interactable");
        _interactables.Add(interactable);
    }
    
    private void OnTriggerExit(Collider other){
        var interactable = other.GetComponent<IInteractable>();
        
        if (interactable == null) return;

        _interactables.Remove(interactable);
        if (interactable != _selected) return;
        
        _selected.GameObject.layer = LayerMask.NameToLayer("Default");
        Debug.Log(_interactables.Count);
        _selected = _interactables.Count == 0 ? null : _interactables[^1];
    }

    public bool Interact(IActor player){
        if (_selected == null) return false;

        if (_selected.Interact(player)){
            _interactables.Remove(_selected);
            _selected.GameObject.layer = LayerMask.NameToLayer("Default");
            if (_interactables.Count == 0){
                _selected = null;
            }
            else{
                _selected = _interactables[^1];
                _selected.GameObject.layer = LayerMask.NameToLayer("Interactable");
            }
            
        }
        return true;
    }
}