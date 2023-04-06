using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInventory
{
    public event Action<Item, bool> OnInventoryChanged; 
    [SerializeField] private List<Item> _inventory;

    public bool ContainItem(in Item item){
        return _inventory.Contains(item);
    }

    public bool AddItem(Item item){
        if (_inventory.Contains(item))
            return false;
        
        _inventory.Add(item);
        OnInventoryChanged?.Invoke(item, true);
        return true;
    }

    public bool RemoveItem(Item item){
        if (!_inventory.Contains(item))
            return false;

        _inventory.Remove(item);
        OnInventoryChanged?.Invoke(item, false);
        return true;
    }
}