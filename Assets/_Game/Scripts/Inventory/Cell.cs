using UnityEngine;

public class Cell : MonoBehaviour
{
    private IItem _item;
    private bool _isBusy;

    public bool TryPlace(IItem item)
    {
        if (_isBusy && _item == item)
        {
            return false;
        }

        _item = item;
        _isBusy = true;
        return true;
    }
}