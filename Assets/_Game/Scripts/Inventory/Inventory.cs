using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private List<Item> _items;
    [SerializeField] private HudItem _renderedHudItem;
    [SerializeField] private List<HudItem> _createdItems;

    private void OnEnable()
    {
        if (_items.Count != 0)
            InitRender(_items);
    }

    private void InitRender(List<Item> items)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (i == _items.Count)
            {
                _items.Clear();
                break;
            }

            if (_cells[i].CanPlace(items[i]))
            {
                CreateHudItem(i, _items[i]);
            }
        }
    }

    public void Insert(Item item)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].CanPlace(item) == false)
                continue;

            if (_createdItems[i] == null)
            {
                CreateHudItem(i, item);
                break;
            }

            _createdItems[i].Init(item);
            break;
        }
    }

    private void CreateHudItem(int index, Item item)
    {
        HudItem tempItem = Instantiate(_renderedHudItem, _cells[index].transform);
        _createdItems.RemoveAt(index);
        _createdItems.Insert(index, tempItem);
        _createdItems[index].Init(item);
    }
}