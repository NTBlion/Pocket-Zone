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
            SaveInventory();
        }
        else
        {
            _items.Add(itemData);

            ItemView itemView = Instantiate(_itemViewPrefab, _itemUIParent);
            itemView.Init(itemData);
            _dataService.SaveData("/inventory.json", _items);
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
        itemView.Init(itemData);
    }
}