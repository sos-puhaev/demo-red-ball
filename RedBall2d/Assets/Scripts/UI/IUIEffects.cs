using System.Collections;
using UnityEngine;

public interface IUIEffects
{
    IEnumerator FadeIn(float duration, Color? targetColor = null);
    IEnumerator FadeOut(float duration);
}