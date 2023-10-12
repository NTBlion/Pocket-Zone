using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public void Render(IItem item)
    {
        _icon.sprite = item.Icon;
    }
}