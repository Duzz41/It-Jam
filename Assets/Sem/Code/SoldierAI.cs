using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class SoldierAI : MonoBehaviour
{
    public Transform target; // Hedef nokta (örneğin, askerin ilk ulaşması gereken nokta)
    public Transform attackPoint; // Saldırı noktası (örneğin, düşmana ateş edilecek nokta)
    public float detectionRadius = 10f; // Düşman algılama yarıçapı
    public LayerMask enemyLayer; // Düşmanın katmanı
    public float attackRange = 2f; // Saldırı menzili
    public float attackCooldown = 2f; // Saldırı bekleme süresi

    public int damage;

    private NavMeshAgent navMeshAgent;
    private Transform nearestEnemy; // En yakın düşman
    private bool isAttacking = false; // Saldırı durumu
    private List<Transform> enemyTransforms = new List<Transform>();
    private float attackTimer = 0f; // Saldırı zamanlayıcı

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination(target.position);
    }

    private void Update()
{
    if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance >= navMeshAgent.stoppingDistance)
    {
        SearchForEnemies();
    }

    if (nearestEnemy != null)
    {
        float distanceToEnemy = Vector3.Distance(transform.position, nearestEnemy.position);

        if (distanceToEnemy <= attackRange && !isAttacking)
        {
            StartCoroutine(nameof(Attack));
        }
        else if (distanceToEnemy > attackRange)
        {
            if (isAttacking)
            {
                StopCoroutine(nameof(Attack));
            }

            navMeshAgent.SetDestination(nearestEnemy.position);
        }
    }
    else if (!isAttacking)
    {
        // Check for enemies within detection radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        if (colliders.Length > 0)
        {
            FindNearestEnemy();
        }
    }

    attackTimer -= Time.deltaTime;
}

    private void SearchForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        enemyTransforms.Clear();

        foreach (Collider col in colliders)
        {
            enemyTransforms.Add(col.transform);
        }

        if (enemyTransforms.Count > 0)
        {
            FindNearestEnemy();
        }
    }

    private void FindNearestEnemy()
{
    float shortestDistance = Mathf.Infinity;
    nearestEnemy = null;

    foreach (Transform enemyTransform in enemyTransforms)
    {
        if(enemyTransform == null) continue; // Skip if the enemy has been destroyed

        float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);
        if (distanceToEnemy < shortestDistance)
        {
            shortestDistance = distanceToEnemy;
            nearestEnemy = enemyTransform;
        }
    }
}
private IEnumerator Attack()
{
    isAttacking = true;

    while (nearestEnemy != null)
    {
        if (attackTimer <= 0f)
        {
            if(nearestEnemy.GetComponent<EnemyStats>() != null) // Check if the enemy still exists
            {
                nearestEnemy.GetComponent<EnemyStats>().TakeDamage(damage);
                Debug.Log("Attacking enemy!");
                attackTimer = attackCooldown;

                SearchForEnemies(); // Update the list of enemies
                FindNearestEnemy(); // Find the nearest enemy again
            }
            else
            {
                isAttacking = false;
                yield break; // Exit the coroutine if the enemy is no longer valid
            }
        }

        yield return null;
    }

    isAttacking = false;
}
    private void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}