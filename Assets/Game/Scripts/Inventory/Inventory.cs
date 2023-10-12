using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private List<Item> _items;
    [SerializeField] private ItemRenderer _renderedItem;
    private void OnEnable()
    {
        Render(_items);
    }

    public void Render(List<Item> items)
    {
        int index = 0;
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].TryPlace())
            {
                Instantiate(_renderedItem,_cells[i].transform).Init(_items[index]);
                index++;
            }
        }
    }
}