using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly List<Item> _items = new();

    [SerializeField] private Transform _itemUIParent;
    [SerializeField] private ItemView _itemViewPrefab;

    private IDataService _dataService;

    public void Init(IDataService dataService)
    {
        _dataService = dataService;
        _dataService.SaveData("/inventory.json", _items);
        _dataService.LoadData<List<Item>>("/inventory.json");
    }

    public void AddItem(Item item)
    {
        Item existingItem = _items.Find(existing => existing.ItemId == item.ItemId);

        if (existingItem != null)
        {
            existingItem.AddCount();
            _dataService.SaveData("/inventory.json", _items);
        }
        else
        {
            _items.Add(item);

            ItemView itemView = Instantiate(_itemViewPrefab, _itemUIParent);
            itemView.Init(item);
            _dataService.SaveData("/inventory.json", _items);
        }
    }
}