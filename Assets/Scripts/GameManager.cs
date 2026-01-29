using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Coin Settings")]
    public int startingCoins = 100;
    public int currentCoins;
    public TextMeshProUGUI coinText;

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
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinUI();
        Debug.Log("+" + amount + " coin! Osszes: " + currentCoins);
    }

    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            UpdateCoinUI();
            return true;
        }
        else
        {
            Debug.Log("Nincs eleg coin!");
            return false;
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "COIN: " + currentCoins;
        }
    }

    // Ez rajzolja ki a kepernyon - Canvas nelkul!
    /*void OnGUI()
    {
        // Stilus beallitasa
        GUIStyle style = new GUIStyle();
        style.fontSize = 40;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        // Kirajzolas a jobb felso sarokba
        GUI.Label(new Rect(Screen.width - 200, 10, 200, 50), "COIN: " + currentCoins, style);
    }*/
}