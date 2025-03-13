using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartArea : MonoBehaviour
{
    public Timer timer;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.enabled = true;
            timer.StartTimer();
        }
    }
}
