using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject, IItem
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
}