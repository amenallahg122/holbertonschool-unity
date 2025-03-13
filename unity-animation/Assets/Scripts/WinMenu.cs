using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        Debug.Log("Returning to MainMenu");
    }

    public void Next()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Time.timeScale = 1f;
            Debug.Log("Loading next level: " + nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
            Debug.Log("No more levels. Returning to MainMenu");
        }
    }
}
