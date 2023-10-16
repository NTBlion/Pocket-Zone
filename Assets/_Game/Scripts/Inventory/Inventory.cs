using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemData> _items = new List<ItemData>();

    [SerializeField] private Transform _itemUIParent;
    [SerializeField] private ItemView _itemViewPrefab;

    private IDataService _dataService;

    public void Init(IDataService dataService)
    {
        _dataService = dataService;

        if (!File.Exists(Application.persistentDataPath + "/inventory.json"))
        {
            SaveInventory();
        }

        LoadInventory();
    }

    public void AddItem(ItemData itemData)
    {
        ItemData existingItemData = _items.Find(existing => existing.ItemId == itemData.ItemId);

        if (existingItemData != null)
        {
            existingItemData.AddCount();
            
            ItemView itemView = FindItemView(existingItemData);
            itemView.RefreshCount();
            
            SaveInventory();
        }
        else
        {
            _items.Add(itemData);

            CreateItemView(itemData);

            SaveInventory();
        }
    }

    public void RemoveItem(ItemData itemData)
    {
        ItemData existingItemData = _items.Find(existing => existing.ItemId == itemData.ItemId);

        if (existingItemData != null)
        {
            ItemView itemView = FindItemView(itemData);

            existingItemData.SubtractCount();
            itemView.RefreshCount();

            if (existingItemData.Count <= 0)
            {
                _items.Remove(existingItemData);

                if (itemView != null)
                {
                    Destroy(itemView.gameObject);
                }
            }

            SaveInventory();
        }
        else
        {
            Debug.LogWarning("Tried to remove item that doesn't exist in the inventory.");
        }
    }

    private void SaveInventory()
    {
        _dataService.SaveData("/inventory.json", _items);
    }

    private void LoadInventory()
    {
        _items.Clear();
        List<ItemData> loadedItems = _dataService.LoadData<List<ItemData>>("/inventory.json");

        if (loadedItems != null)
        {
            _items.AddRange(loadedItems);
        }

        foreach (ItemData item in _items)
        {
            CreateItemView(item);
        }
    }

    private void CreateItemView(ItemData itemData)
    {
        ItemView itemView = Instantiate(_itemViewPrefab, _itemUIParent);
        itemView.Init(itemData, this);
    }

    private ItemView FindItemView(ItemData itemData)
    {
        foreach (Transform child in _itemUIParent)
        {
            ItemView itemView = child.GetComponent<ItemView>();
            if (itemView != null && itemView.GetItemData() == itemData)
            {
                return itemView;
            }
        }

        return null;
    }
}