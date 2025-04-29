using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button startGame;
    [SerializeField] Button ExitGame;

    void Start()
    {
        startGame.onClick.AddListener(StartGame);
        ExitGame.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
