using UnityEngine;

public class GameItem : MonoBehaviour, IItem
{
    [SerializeField] private AssetItem _assetItem;
    [SerializeField] private SpriteRenderer _sprite;
    
    public Sprite Icon => _sprite.sprite;

    private Inventory _inventory;
    
    private void Start()
    {
        _sprite.sprite = _assetItem.Icon;
    }
}