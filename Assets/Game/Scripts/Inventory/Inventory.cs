using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private List<Item> _items;
    [SerializeField] private ItemRenderer _renderedItem;

    private void OnEnable()
    {
        if (_items.Count != 0)
            Render(_items);
    }

    public void Render(List<Item> items)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].TryPlace())
            {
                if (i == _items.Count)
                {
                    _items.Clear();
                    break;
                }

                Instantiate(_renderedItem, _cells[i].transform).Init(_items[i]);
            }
        }
    }
}