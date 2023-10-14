using UnityEngine;

public class Cell : MonoBehaviour
{
    private Item _item;
    private bool _isBusy;

    public bool CanPlace(Item item)
    {
        if (_isBusy)
        {
            return _item.Id == item.Id;
        }

        _item = item;
        _isBusy = true;
        return true;
    }

    public void Clear()
    {
        _isBusy = false;
        _item = null;
    }
}