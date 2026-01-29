using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int health = 20;

    void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int amount)
    {
        if (GameManager.Instance.isGameEnded) return;

        health -= amount;
        if (health < 0) health = 0;
        Debug.Log("Bázis sérült! Élet: " + health);

        if (health <= 0)
        {
            GameManager.Instance.GameOver(); 
        }
    }
}