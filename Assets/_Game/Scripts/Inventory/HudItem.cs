using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudItem : MonoBehaviour
{
    private readonly string _emptyString = "";
    
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private Button _deleteButton;

    private int _count;

    public event Action Deleted;

    public void Init(GameItem item)
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
            Deleted?.Invoke();
            Destroy(gameObject);
        }

        _count--;
        _deleteButton.gameObject.SetActive(false);
        _countText.text = _count.ToString();

        if (_count == 1)
            _countText.text = _emptyString;
    }
}