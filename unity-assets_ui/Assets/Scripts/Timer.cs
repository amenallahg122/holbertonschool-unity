using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    private float timeElapsed = 0f;
    
    void Update()
    {
        timeElapsed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = timeElapsed % 60;
        
        string formattedTime = string.Format("{0:00}:{1:00.00}", minutes, seconds);
        
        timerText.text = formattedTime;
    }
}
