using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Button ButtonPause;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;

    void Start()
    {
        InitializeUIButtons();
        gameOverPanel.SetActive(false);
    }

    void InitializeUIButtons()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        ButtonPause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        ButtonPause.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
