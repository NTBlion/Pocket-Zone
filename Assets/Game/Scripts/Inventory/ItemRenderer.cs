using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemRenderer : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;

    private int _count;
    
    public void Init(IItem item)
    {
        _icon.sprite = item.Icon;
        _countText.text = _count++.ToString();
    }
}