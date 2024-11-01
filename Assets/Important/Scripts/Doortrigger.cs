using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Transform doorPivot = null;
    [SerializeField] private Collider doorCollider = null;
    [SerializeField] private Animator door = null;
    [SerializeField] private GameObject openSound;
    private AudioSource openSoundPlayer;
    [SerializeField] private GameObject closeSound;
    private AudioSource closeSoundPlayer;


    [SerializeField] private bool doorClosed = true;

    private void Start()
    {
        openSoundPlayer = openSound.GetComponent<AudioSource>();
        closeSoundPlayer = closeSound.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            //Debug.Log("active");
            Debug.Log(doorPivot.localRotation.eulerAngles.y);
            
            if (doorClosed && doorPivot.rotation.eulerAngles.y == 0f)
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
                doorCollider.isTrigger = true;
                openSoundPlayer.Play();
            }
            else if (!doorClosed && (doorPivot.rotation.eulerAngles.y == 90f || doorPivot.rotation.eulerAngles.y == 270f))
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
                doorCollider.isTrigger = false;
                closeSoundPlayer.Play();
            }
        }
    }
}
