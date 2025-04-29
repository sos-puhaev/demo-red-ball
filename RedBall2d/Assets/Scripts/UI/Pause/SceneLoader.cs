using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    [SerializeField] Image loadPanel;

    public IEnumerator RestartWithFade()
    {
        yield return StartCoroutine(FadeScreen(1f)); 
        Scene currentScene = SceneManager.GetActiveScene();
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(currentScene.name);
    }

    public IEnumerator LoadMainMenuWithFade()
    {
        yield return StartCoroutine(FadeScreen(1f));
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator FadeScreen(float duration)
    {
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = currentTime / duration;
            loadPanel.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
    }
}
