using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> Items;
    [SerializeField] private InventoryCell _cell;
    [SerializeField] private Transform _container;
    private void OnEnable()
    {
        Render(Items);
    }

    public void Render(List<Item> items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);
        
        foreach (var item in items)
        {
            var cell = Instantiate(_cell, _container);
            cell.Render(item);
        }
    }
}