using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneActivator : MonoBehaviour
{
    [SerializeField] GameObject phone;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            phone.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
