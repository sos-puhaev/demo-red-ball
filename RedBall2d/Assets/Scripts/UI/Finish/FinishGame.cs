using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] Button ButtonPause;
    [SerializeField] GameObject gameFinishPanel;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button nextLevelButton;

    void Start()
    {
        InitializeUIButtons();
        gameFinishPanel.SetActive(false);
    }

    void InitializeUIButtons()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowGameFinishPanel()
    {
        gameFinishPanel.SetActive(true);
        ButtonPause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        ButtonPause.gameObject.SetActive(true);
        gameFinishPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
