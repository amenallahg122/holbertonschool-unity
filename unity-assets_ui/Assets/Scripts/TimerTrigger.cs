using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimerTrigger : MonoBehaviour
{
    public Timer timer;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (timer != null)
            {
                timer.enabled = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}