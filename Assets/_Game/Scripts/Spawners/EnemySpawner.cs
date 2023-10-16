using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private int _enemyCount;
    [SerializeField] private Collider2D _spawnArea;

    public void Spawn()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Instantiate(_enemyTemplate, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }


    private Vector2 GetRandomSpawnPosition()
    {
        Bounds bounds = _spawnArea.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}