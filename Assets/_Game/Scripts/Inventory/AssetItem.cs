using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, IItem
{
    [SerializeField] private Sprite _icon;

    public Sprite Icon => _icon;
}