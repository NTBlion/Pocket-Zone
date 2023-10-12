using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private IItem _item;
    private bool _isBusy = false;

    public bool TryPlace()
    {
        if (_isBusy)
        {
            return false;
        }

        _isBusy = true;
        return true;
    }
}