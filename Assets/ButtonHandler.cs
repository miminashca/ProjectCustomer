using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private bool buttonOn;
    private bool buttonHit;
    private GameObject button;

    public GameObject Interactable;

    private float buttonHitResetTime = 0.5f;
    private float canHitAgain;

    [SerializeField] bool bath;
    [SerializeField] bool sink;
    [SerializeField] bool valve;
    [SerializeField] bool lightswitch;

    bool bathfull;
    bool sinkfull;
    bool valveOn;
    bool lightsOn;
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

            if (buttonOn)
            {
                if (bath)
                {
                    bathfull = true;
                }
                if (sink)
                {
                    sinkfull = true;
                }
                if (lightswitch)
                {
                    lightsOn = true;
                }
                if (valve)
                {
                    valveOn = true;
                }
                Interactable.SetActive(true);
            }
            else
            {
                Interactable.SetActive(false);

                if (bath)
                {
                    bathfull = false;
                }
                if (sink)
                {
                    sinkfull = false;
                }
                if (lightswitch)
                {
                    lightsOn = false;
                }
                if (valve)
                {
                    valveOn = false;
                }
            }
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
