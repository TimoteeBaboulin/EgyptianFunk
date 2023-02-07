using UnityEngine;

[CreateAssetMenu(menuName = "Create Item", fileName = "Item", order = 0)]
public class Item : ScriptableObject{
    public Sprite Sprite => _sprite;
    [SerializeField] private Sprite _sprite;

    public string Name => _name;
    [SerializeField] private string _name;
}