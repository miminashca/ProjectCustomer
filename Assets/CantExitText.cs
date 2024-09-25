using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CantExitText : MonoBehaviour
{
    public GameObject cantExit;
    // Start is called before the first frame update
    void Start()
    {
        cantExit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            cantExit.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            cantExit.SetActive(false);
        }
    }
}
