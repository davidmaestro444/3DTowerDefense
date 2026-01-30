using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;

    public void OpenLevelSelector()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void CloseLevelSelector()
    {
        levelSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}