using System.Collections;
public interface ISceneLoader
{
    IEnumerator RestartWithFade();
    IEnumerator LoadMainMenuWithFade();
}