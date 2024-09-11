using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private bool doorClosed = true;
    private bool doorOpen = false;
    private bool doorIsActive = false;

    private void Start()
    {
        doorOpen = !doorClosed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && doorIsActive)
        {
            if (doorOpen)
            {
                door.Play("DoorClose");
                doorOpen = false;
                doorClosed = true;
            }
            if (doorClosed)
            {
                door.Play("DoorOpen");
                doorOpen = true;
                doorClosed = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            Debug.Log("active");
            doorIsActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            Debug.Log("not active");
            doorIsActive = false;
        }
    }
}
