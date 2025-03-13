using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text FinalTime;

    private static float timeElapsed = 0f;
    private bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            float seconds = timeElapsed % 60;

            string formattedTime = string.Format("{0:00}:{1:00.00}", minutes, seconds);
            timerText.text = formattedTime;
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void Win()
    {
        Debug.Log("Win method called!");
        isRunning = false;

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = timeElapsed % 60;

        string formattedTime = string.Format("{0:00}:{1:00.00}", minutes, seconds);

        if (FinalTime != null)
        {
            FinalTime.text = formattedTime;
            Debug.Log("Final Time: " + formattedTime);
        }
        else
        {
            Debug.LogError("FinalTime UI element is not assigned!");
        }
    }

    public static void ResetTimer()
    {
        timeElapsed = 0f;
    }
}
