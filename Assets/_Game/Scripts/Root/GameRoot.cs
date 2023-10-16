using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private readonly IDataService _dataService = new JsonDataService();
    
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private JoystickMovement _joystick;

    [Header("Player")] [SerializeField] private Player _player;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private WeaponRotation _weaponRotation;
    [SerializeField] private Detector _playerDetector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CharacterHealth _playerHealth;
    
    [Header("Enemy")] [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ItemSpawner _itemSpawner;

    [Header("Inventory")] [SerializeField] private Inventory _inventory;
    

    private void Awake()
    {
        _player.Init(_joystick, _playerDetector, _playerMovement, _playerRotation, _weaponRotation);
        _camera.Init(_playerHealth);
        _playerRotation.Init(_joystick);
        _weaponRotation.Init(_joystick);
        _playerMovement.Init(_joystick);
        _itemSpawner.Init(_inventory);
        _enemySpawner.Spawn();
        _inventory.Init(_dataService);
    }
}