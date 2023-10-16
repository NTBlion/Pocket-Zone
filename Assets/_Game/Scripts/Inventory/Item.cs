using System;
using UnityEngine;

[Serializable]
public class Item
{
    public int ItemId { get; private set; }
    public int Count { get; private set; }
    public Sprite Icon { get; private set; }
    
    public Item(int id, int count, Sprite icon)
    {
        ItemId = id;
        Count = count;
        Icon = icon;
    }

    public event Action CountAdd;
    public event Action CountGotOne;
    public event Action CountGotMoreThanOne;
    public event Action CountGotZero;
    
    public void AddCount()
    {
        Count++;
        if (Count > 1)
            CountGotMoreThanOne?.Invoke();
        
        CountAdd?.Invoke();
    }

    public void RemoveCount()
    {
        Count--;
        
        if (Count == 1)
            CountGotOne?.Invoke();
        
        if (Count < 1)
            CountGotZero?.Invoke();
    }
}