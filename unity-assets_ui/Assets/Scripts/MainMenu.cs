using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the selected level based on the passed integer
    public void LevelSelect(int level)
    {
        string sceneName = $"Level{level:00}";
        SceneManager.LoadScene(sceneName);
    }

    // Load the Options scene
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Exit the game
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
