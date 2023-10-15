using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudItem : MonoBehaviour
{
    private const string EMPTY = "";

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private Button _deleteButton;
    
    private int _count;
    
    public void Init(Item item)
    {
        _icon.sprite = item.Sprite.sprite;
        _count++;
        
        if (_count > 1)
            _countText.text = _count.ToString();
        
    }

    public void Delete()
    {
        if (_count == 1)
        {
            GetComponentInParent<Cell>().Clear();
            Destroy(gameObject);
        }

        _count--;
        _deleteButton.gameObject.SetActive(false);
        _countText.text = _count.ToString();

        if (_count == 1)
            _countText.text = EMPTY;
    }
}