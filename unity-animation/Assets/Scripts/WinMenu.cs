using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public Timer timer;

    public void MainMenu()
    {
        if (timer != null)
        {
            Timer.ResetTimer();
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Returning to MainMenu");
    }

    public void Next()
    {
        if (timer != null)
        {
            Timer.ResetTimer();
        }

        Time.timeScale = 1f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Loading next level: " + nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("No more levels. Returning to MainMenu");
        }
    }
}
