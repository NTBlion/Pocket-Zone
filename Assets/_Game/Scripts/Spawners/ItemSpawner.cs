using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private CharacterHealth _enemy;
    [SerializeField] private ItemGameObject[] _items;

    [SerializeField] private Inventory _inventory;

    public void Init(Inventory inventory) => _inventory = inventory;

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(_items[Random.Range(0, _items.Length)], transform.position, quaternion.identity).Init(_inventory);
    }
}
