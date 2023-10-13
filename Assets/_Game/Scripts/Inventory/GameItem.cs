using UnityEngine;

public class GameItem : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private SpriteRenderer _sprite;

    public SpriteRenderer Sprite => _sprite;
    public int Id => _id;
}