using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudItem : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private Button _deleteButton;

    private int _count;

    public void Init(IItem item)
    {
        _icon.sprite = item.Icon;
        _count++;
        
        if (_count > 1)
            _countText.text = _count.ToString();
    }

    public void Delete()
    {
        if (_count == 1)
            Destroy(gameObject);

        _count--;
        _deleteButton.gameObject.SetActive(false);
        _countText.text = _count.ToString();

        if (_count == 1)
            _countText.text = "";
    }
}