using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _itemCountText;

    private Item _item;

    public void Init(Item item)
    {
        _item = item;
        _item.CountAdd += OnCountAdd;
        _item.CountGotOne += OnCountGotOne;
        _item.CountGotZero += OnCountGotZero;
        _item.CountGotMoreThanOne += OnCountGotMoreThanOne;
        _icon.sprite = item.Icon;
        _itemCountText.text = _item.Count.ToString();
    }

    private void OnDisable()
    {
        _item.CountAdd -= OnCountAdd;
        _item.CountGotOne -= OnCountGotOne;
        _item.CountGotZero -= OnCountGotZero;
        _item.CountGotMoreThanOne -= OnCountGotMoreThanOne;
    }

    public void Delete()
    {
        if (_item.Count > 1)
        {
            _item.RemoveCount();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCountGotMoreThanOne()
    {
        _itemCountText.gameObject.SetActive(true);
    }

    private void OnCountGotZero()
    {
        Delete();
    }

    private void OnCountGotOne()
    {
        _itemCountText.gameObject.SetActive(false);
    }

    private void OnCountAdd()
    {
        _itemCountText.text = _item.Count.ToString();
    }
}