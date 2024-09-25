using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStarter : MonoBehaviour
{
    bool firstExit = true;
    TimeCountdown timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindAnyObjectByType<TimeCountdown>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (firstExit && other.CompareTag("PlayerHead"))
        {
            timer.leftRoom = true;
            firstExit = false;
        }
    }
}
