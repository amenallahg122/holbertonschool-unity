using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private int previousSceneIndex;

    void Start()
    {
        invertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
        previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 0);
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("InvertY", invertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(previousSceneIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}
