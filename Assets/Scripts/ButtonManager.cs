using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit_Game()
    {
        Application.Quit();
    }

    public void LoadSite(string url)
    {
        Application.OpenURL(url);
    }
}