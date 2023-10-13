using UnityEngine;

public class Cell : MonoBehaviour
{
    private GameItem _item;
    private bool _isBusy;

    public bool CanPlace(GameItem item)
    {
        if (_isBusy)
        {
            return _item.Id == item.Id;
        }

        _item = item;
        _isBusy = true;
        return true;
    }
}