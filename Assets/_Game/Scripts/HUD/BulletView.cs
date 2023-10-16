using UnityEngine;
using TMPro;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TMP_Text _bulletCountText;

    private void OnEnable()
    {
        _weapon.Shot += OnShot;
    }

    private void OnDisable()
    {
        _weapon.Shot -= OnShot;
    }

    private void OnShot(int bulletCount)
    {
        _bulletCountText.text = bulletCount.ToString();
    }
}