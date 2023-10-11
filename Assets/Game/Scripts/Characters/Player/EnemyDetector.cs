using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] [Min(1f)] private float _detectionRadius;
    [SerializeField] private LayerMask _enemyLayer;

    private Collider2D[] _collidersBuffer = new Collider2D[10];

    public Enemy FindNearestEnemy()
    {
        int hitCount =
            Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _collidersBuffer, _enemyLayer);

        float closestDistance = Mathf.Infinity;
        Enemy closestEnemy = null;

        for (int i = 0; i < hitCount; i++)
        {
            float distance = Vector2.Distance(transform.position, _collidersBuffer[i].transform.position);

            if (distance < closestDistance)
            {
                if (_collidersBuffer[i].TryGetComponent(out Enemy enemy))
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}