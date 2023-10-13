using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameItem _item;
    [SerializeField] private bool _isBusy;

    public bool CanPlace(GameItem item)
    {
       // item.Destroyd
        
        if (_isBusy)
        {
            return _item.Id == item.Id;
        }

        _item = item;
        _isBusy = true;
        return true;
    }
}