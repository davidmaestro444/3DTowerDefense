using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Coin Settings")]
    public int startingCoins = 100;
    public int currentCoins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentCoins = startingCoins;
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        Debug.Log("+" + amount + " coin! Osszes: " + currentCoins);
    }

    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            return true;
        }
        else
        {
            Debug.Log("Nincs eleg coin!");
            return false;
        }
    }

    // Ez rajzolja ki a kepernyon - Canvas nelkul!
    void OnGUI()
    {
        // Stilus beallitasa
        GUIStyle style = new GUIStyle();
        style.fontSize = 40;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        // Kirajzolas a jobb felso sarokba
        GUI.Label(new Rect(Screen.width - 200, 10, 200, 50), "COIN: " + currentCoins, style);
    }
}