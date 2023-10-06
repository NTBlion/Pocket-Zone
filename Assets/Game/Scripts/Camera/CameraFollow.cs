using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Player _player;
    private Camera _camera;

    public void Init(Player player)
    {
        _player = player;
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        _camera.transform.position = _player.transform.position + _offset;
    }
}