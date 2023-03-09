using UnityEngine;

public interface IActor{
    public PlayerInventory Inventory{ get; }
    public Vector3 Position{ get; }
}