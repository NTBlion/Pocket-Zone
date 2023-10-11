using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private JoystickMovement _joystick;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private WeaponRotation _weaponRotation;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private EnemySpawner _spawner;

    private void Awake()
    {
        _player.Init(_joystick, _enemyDetector, _playerMovement,_playerRotation, _weaponRotation);
        _camera.Init(_player);
        _playerRotation.Init(_joystick);
        _weaponRotation.Init(_joystick);
        _playerMovement.Init(_joystick);
        _spawner.Spawn();
    }
}