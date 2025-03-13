using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas;
    public Timer timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (winCanvas != null)
            {
                winCanvas.SetActive(true);
            }
            else
            {
                Debug.LogError("Win Canvas is not assigned!");
            }

            if (timer != null)
            {
                timer.Win();
            }
            else
            {
                Debug.LogError("Timer script is not assigned!");
            }

            Time.timeScale = 0f;
        }
    }
}
