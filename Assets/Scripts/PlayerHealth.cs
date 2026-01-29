using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int Lives;
    public int startLives = 20;

    void Start()
    {
        Lives = startLives;
    }
}
