using UnityEngine;

public class ItemGameObject : MonoBehaviour
{
    [SerializeField] private int _itemId;
    [SerializeField] private int _count = 1;
    [SerializeField] private SpriteRenderer _icon;

    private Inventory _inventory;
    private ItemData _itemData;
    
    public void Init(Inventory inventory) => _inventory = inventory;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _itemData = new ItemData(_itemId, _count, _icon.sprite);

            _inventory.AddItem(_itemData);

            Destroy(gameObject);
        }
    }
}