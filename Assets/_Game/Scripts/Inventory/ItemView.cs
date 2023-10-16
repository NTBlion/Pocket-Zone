using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _itemCountText;

    private ItemData _itemData;

    public void Init(ItemData itemData)
    {
        _itemData = itemData;
        _icon.sprite = _itemData.GetIcon();
        RefreshCount();
    }

    public void RefreshCount()
    {
        _itemCountText.text = _itemData.Count.ToString();
    }
}