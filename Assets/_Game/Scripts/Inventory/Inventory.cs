using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private HudItem _renderedHudItem;

    [SerializeField] private List<HudItem> _createdItems = new List<HudItem>(20);

    private void OnEnable()
    {
        if (_items.Count != 0)
            InitRender(_items);
    }

    private void InitRender(List<AssetItem> items)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (i == _items.Count)
            {
                _items.Clear();
                break;
            }

            if (_cells[i].TryPlace(items[i]))
            {
                var tempItem = Instantiate(_renderedHudItem, _cells[i].transform);
                _createdItems.RemoveAt(i);
                _createdItems.Insert(i, tempItem);
                _createdItems[i].Init(_items[i]);
            }
        }
    }

    public void Insert(IItem item)
    {
        for (int i = 0; i < _createdItems.Count; i++)
        {
            if (_cells[i].TryPlace(item))
            {
                
                if (_createdItems[i] == null)
                {
                    var tempItem = Instantiate(_renderedHudItem, _cells[i].transform);
                    _createdItems.RemoveAt(i); 
                    _createdItems.Insert(i, tempItem);
                    tempItem.Init(item);
                    break;
                }
            }
        }
    }
}