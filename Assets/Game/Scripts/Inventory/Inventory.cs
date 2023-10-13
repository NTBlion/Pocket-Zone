using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private List<Item> _items;
    [SerializeField] private ItemRenderer _renderedItem;

    private List<ItemRenderer> _createdItems = new List<ItemRenderer>();
    
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

            if (_cells[i].TryPlace(items[i]))
            {
                _createdItems.Add(Instantiate(_renderedItem, _cells[i].transform));
                _createdItems[i].Init(_items[i]);
            }
        }
    }

    public void Insert(IItem item)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].TryPlace(item))
            {
                _createdItems[i].Init(item);
                break;
            }
        }
    }
}