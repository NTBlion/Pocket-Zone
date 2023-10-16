using UnityEngine;

public class ItemGameObject : MonoBehaviour
{
    [SerializeField] private int _itemId;
    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private Inventory _inventory;

    //private Inventory _inventory;

    public void Init(Inventory inventory) => _inventory = inventory;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Item newItem = new Item(_itemId, 1, _icon.sprite);

           _inventory.AddItem(newItem);

            Destroy(gameObject);
        }
    }
}