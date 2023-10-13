using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject, IItem
{
    [SerializeField] private Sprite _icon;

    public Sprite Icon => _icon;
}