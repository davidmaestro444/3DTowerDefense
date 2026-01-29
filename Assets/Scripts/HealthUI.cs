using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthBar;

    void Update()
    {
        healthBar.value = PlayerHealth.Lives;
    }
}
