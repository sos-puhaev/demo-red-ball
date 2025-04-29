using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    [SerializeField] Button Pause;
    [SerializeField] Button Resume;
    [SerializeField] Button Restart;
    [SerializeField] Button mainMenu;
    [SerializeField] GameObject Panel;

    [SerializeField] MonoBehaviour sceneLoaderObject;
    [SerializeField] MonoBehaviour uiEffectsObject;
    ISceneLoader sceneLoader;
    IUIEffects uiEffects;


    void Awake()
    {
        sceneLoader = sceneLoaderObject as ISceneLoader;
        uiEffects = uiEffectsObject as IUIEffects;

        if (sceneLoader == null)
            Debug.LogError("SceneLoader object does not implement ISceneLoader!");
        if (uiEffects == null)
            Debug.LogError("UIEffects object does not implement IUIEffects!");
    }

    void Start()
    {
        InitializeUIButtons();
    }

    void InitializeUIButtons()
    {
        if (Pause != null)
            Pause.onClick.AddListener(ShowMenu);
        if (Resume != null)
            Resume.onClick.AddListener(HideMenu);
        if (Restart != null)
            Restart.onClick.AddListener(GameRestart);
        if (mainMenu != null)
            mainMenu.onClick.AddListener(GoToMainMenu);
    }

    void ShowMenu()
    {
        Time.timeScale = 0;
        Pause.gameObject.SetActive(false);
        Panel.SetActive(true);
    }

    void HideMenu()
    {
        Time.timeScale = 1;
        Pause.gameObject.SetActive(true);
        Panel.SetActive(false);
    }

    void GameRestart()
    {
        Time.timeScale = 1;
        Panel.SetActive(false);

        if (sceneLoader != null)
            StartCoroutine(sceneLoader.RestartWithFade());
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1;

        if (sceneLoader != null)
            StartCoroutine(sceneLoader.LoadMainMenuWithFade());
    }
}
