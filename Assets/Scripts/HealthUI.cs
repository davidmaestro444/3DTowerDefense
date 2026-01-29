using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthBar;
    void Start()
    {
        if (PlayerHealth.Instance != null)
        {
            healthBar.maxValue = PlayerHealth.Instance.health;
            healthBar.value = PlayerHealth.Instance.health;
        }
    }

    void Update()
    {
        if (PlayerHealth.Instance != null)
        {
            healthBar.value = PlayerHealth.Instance.health;
        }
    }
}
