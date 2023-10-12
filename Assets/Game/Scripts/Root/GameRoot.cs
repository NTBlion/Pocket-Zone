using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private JoystickMovement _joystick;

    [Header("Player")] [SerializeField] private Player _player;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private WeaponRotation _weaponRotation;
    [SerializeField] private Detector _playerDetector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CharacterHealth _playerHealth;

    [Header("Enemy")] [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Detector _enemyDetector;

    private void Awake()
    {
        _player.Init(_joystick, _playerDetector, _playerMovement, _playerRotation, _weaponRotation);
        _camera.Init(_player);
        _playerRotation.Init(_joystick);
        _weaponRotation.Init(_joystick);
        _playerMovement.Init(_joystick);
        _spawner.Init(_enemyMovement, _enemyDetector);
        _spawner.Spawn();
    }
}