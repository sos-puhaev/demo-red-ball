using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEffects : MonoBehaviour, IUIEffects
{
    [SerializeField] Image loadPanel;

    void Awake()
    {
        if (loadPanel == null)
        {
            Debug.LogError("Load Panel is not assigned in UIEffects!");
        }
        else
        {
            SetAlpha(0f);
        }
    }

    public IEnumerator FadeIn(float duration, Color? targetColor = null)
    {
        if (loadPanel == null) yield break;

        Color color = targetColor ?? Color.black;
        color.a = 0f;
        loadPanel.color = color;

        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = Mathf.Clamp01(currentTime / duration);
            loadPanel.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeOut(float duration)
    {
        if (loadPanel == null) yield break;

        Color color = loadPanel.color;
        color.a = 1f;
        loadPanel.color = color;

        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = 1f - Mathf.Clamp01(currentTime / duration);
            loadPanel.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }

    void SetAlpha(float alpha)
    {
        if (loadPanel != null)
        {
            Color color = loadPanel.color;
            color.a = alpha;
            loadPanel.color = color;
        }
    }
}
