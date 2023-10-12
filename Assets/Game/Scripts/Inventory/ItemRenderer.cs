using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemRenderer : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;

    private int _count = 0;
    
    public void Init(IItem item)
    {
        _icon.sprite = item.Icon;
        _count++;
        _countText.text = _count.ToString();
    }
}