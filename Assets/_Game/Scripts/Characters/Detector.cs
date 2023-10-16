using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] [Min(1f)] private float _detectionRadius;
    [SerializeField] private LayerMask _layer;

    private Collider2D[] _collidersBuffer = new Collider2D[10];

    public CharacterHealth FindNearestEnemy()
    {
        int hitCount =
            Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _collidersBuffer, _layer);

        float closestDistance = Mathf.Infinity;
        CharacterHealth closestEnemy = null;

        for (int i = 0; i < hitCount; i++)
        {
            float distance = Vector2.Distance(transform.position, _collidersBuffer[i].transform.position);

            if (distance < closestDistance)
            {
                if (_collidersBuffer[i].TryGetComponent(out CharacterHealth enemy))
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