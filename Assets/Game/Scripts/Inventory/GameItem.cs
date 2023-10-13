using UnityEngine;

public class GameItem : MonoBehaviour, IItem
{
    [SerializeField] private Item _item;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Inventory _inventory;
    public Sprite Icon => _sprite.sprite;

    private void Start()
    {
        _sprite.sprite = _item.Icon;
        _inventory.Insert(this);
    }

}