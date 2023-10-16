using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryArea;

    private bool _isOpened;

    public void OpenCloseInventory()
    {
        _isOpened = !_isOpened;
        _inventoryArea.SetActive(_isOpened);
        
    }
}
