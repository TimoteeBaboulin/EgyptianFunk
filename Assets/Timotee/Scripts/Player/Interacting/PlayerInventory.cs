using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInventory{
    [SerializeField] private List<Item> _inventory;

    public bool ContainItem(in Item item){
        return _inventory.Contains(item);
    }

    public bool AddItem(Item item){
        if (_inventory.Contains(item))
            return false;
        
        _inventory.Add(item);
        return true;
    }

    public bool RemoveItem(Item item){
        if (!_inventory.Contains(item))
            return false;

        _inventory.Remove(item);
        return true;
    }
}