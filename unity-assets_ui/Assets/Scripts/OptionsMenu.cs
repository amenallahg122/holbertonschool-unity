using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public void Back()
    {
        int previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 0);

        SceneManager.LoadScene(previousSceneIndex);
    }
}
