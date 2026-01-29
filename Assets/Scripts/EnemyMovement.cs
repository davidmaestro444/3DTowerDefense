using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float turnSpeed = 10f;

    [Header("Health")]
    public int maxHealth = 4;
    private int currentHealth;

    [Header("Damage & Reward")]
    public int damageToPlayer = 1;
    public int coinReward = 10;

    [Header("Enemy Type")]
    public EnemyType enemyType = EnemyType.Soldier;

    private int waypointIndex = 1;

    public enum EnemyType
    {
        Soldier,
        Wizard,
        Grunt,
        Golem
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        if (waypointIndex >= waypoints.Length)
        {
            EndPath();
            return;
        }

        Transform targetWaypoint = waypoints[waypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.4f)
        {
            waypointIndex++;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Coin jutalom
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(coinReward);
        }

        // Spawner ertesitese a halálárol
        if (Spawner.Instance != null)
        {
            Spawner.Instance.EnemyKilled(enemyType);
        }

        Debug.Log(enemyType + " meghalt! +" + coinReward + " coin");
        Destroy(gameObject);
    }

    void EndPath()
    {
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.TakeDamage(damageToPlayer);
        }
        Destroy(gameObject);
    }
}