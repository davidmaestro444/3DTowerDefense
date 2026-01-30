using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Coin Settings")]
    public int startingCoins = 200;
    public int currentCoins;
    public TextMeshProUGUI coinText;
    public GameObject winUI;

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
            coinText.text = "Coin: " + currentCoins;
        }
    }

    [Header("Game Over Settings")]
    public GameObject gameOverUI;
    public bool isGameEnded = false;

    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        Debug.Log("GAME OVER!");
        Time.timeScale = 0f;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void WinGame()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        Debug.Log("GYÕZELEM!");
        Time.timeScale = 0f;

        if (winUI != null)
        {
            winUI.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}