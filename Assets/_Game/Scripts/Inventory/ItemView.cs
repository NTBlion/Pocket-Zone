using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _itemCountText;

    private Inventory _inventory;
    private ItemData _itemData;

    public void Init(ItemData itemData, Inventory inventory)
    {
        _itemData = itemData;
        _inventory = inventory;
        _icon.sprite = _itemData.GetIcon();
        RefreshCount();
        if (_itemData.Count > 1)
            _itemCountText.gameObject.SetActive(true);
    }

    public void RefreshCount()
    {
        _itemCountText.text = _itemData.Count.ToString();
    }

    public ItemData GetItemData()
    {
        return _itemData;
    }

    public void Delete()
    {
        _inventory.RemoveItem(_itemData);
        RefreshCount();
        
        if (_itemData.Count < 2)
            _itemCountText.gameObject.SetActive(false);
    }
}