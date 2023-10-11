using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 2f;
    [SerializeField] private LayerMask _enemyLayer;

    private Collider2D[] _collidersBuffer = new Collider2D[10];

    public Enemy FindNearestEnemy()
    {
        int hitCount =
            Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _collidersBuffer, _enemyLayer);

        float closestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        for (int i = 0; i < hitCount; i++)
        {
            float distance = Vector2.Distance(transform.position, _collidersBuffer[i].transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = _collidersBuffer[i].GetComponent<Enemy>();
            }
        }

        return nearestEnemy;
    }
}