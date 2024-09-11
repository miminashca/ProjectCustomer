using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doortrigger : MonoBehaviour
{
    [SerializeField] private Transform doorPivot = null;
    [SerializeField] private Animator door = null;
    private bool doorIsActive = false;
    
    [SerializeField] private bool doorClosed = true;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            if (!doorIsActive)
            {
                doorIsActive = true;
            }
            else
            {
                doorIsActive = false;
            }
            
            if (doorClosed && doorIsActive)
            {
                if (gameObject.CompareTag("LeftDoorTrigger"))
                {
                    door.Play("DoorOpenLeft");
                }
                if (gameObject.CompareTag("RightDoorTrigger"))
                {
                    door.Play("DoorOpenRight");
                }

                doorClosed = false;
            }
            else if (!doorClosed && doorIsActive)
            {
                if (gameObject.CompareTag("LeftDoorTrigger"))
                {
                    door.Play("DoorCloseLeft");
                }
                if (gameObject.CompareTag("RightDoorTrigger"))
                {
                    door.Play("DoorCloseRight");
                }

                doorClosed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            doorIsActive = false;
        }
    }
}
