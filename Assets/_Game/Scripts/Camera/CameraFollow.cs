using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private CharacterHealth _player;
    private Camera _camera;
    private bool _isPlayerAlive;


    public void Init(CharacterHealth player)
    {
        _player = player;
        _camera = Camera.main;
        _isPlayerAlive = true;
        _player.Died += OnDied;
    }

    private void OnDied()
    {
        _isPlayerAlive = false;
    }

    private void LateUpdate()
    {
        if (_isPlayerAlive)
            _camera.transform.position = _player.transform.position + _offset;
    }
}