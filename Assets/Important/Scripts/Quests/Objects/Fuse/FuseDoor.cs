using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [NonSerialized] public bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            if (!isOpen)
            {
                animator.Play("FuseDoorOpen");
                isOpen = true;
            }
        }
    }
}
