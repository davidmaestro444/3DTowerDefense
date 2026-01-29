using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float turnSpeed = 10f;

    [Header("Health")]
    public int maxHealth = 4;
    private int currentHealth;

    [Header("Coin Reward")]
    public int coinReward = 10;

    private int waypointIndex = 1;

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
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(coinReward);
        }
        Debug.Log("Ellenség meghalt! +" + coinReward + " coin");
        Destroy(gameObject);
    }

    void EndPath()
    {
        if (PlayerHealth.Lives > 0) 
        {
            PlayerHealth.Lives--; 
            Debug.Log("Ellenség bejutott! Hátralévő élet: " + PlayerHealth.Lives);
        }

        if (PlayerHealth.Lives <= 0)
        {
            Debug.Log("GAME OVER!"); 
        }

        Destroy(gameObject); 
    }
}