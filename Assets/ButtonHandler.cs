using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private bool buttonOn;
    private bool buttonHit;
    private GameObject button;

    public GameObject plane;

    private float buttonHitResetTime = 0.5f;
    private float canHitAgain;
    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonHit)
        {
            buttonHit = false;

            buttonOn = !buttonOn;

            if(buttonOn)
            {
                plane.SetActive(true);
            }
            else plane.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHand") && canHitAgain < Time.time)
        {
            canHitAgain = Time.time + buttonHitResetTime;
            buttonHit = true;
        }
    }
}
