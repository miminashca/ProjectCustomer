using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInteraction : MonoBehaviour
{

    public float playerReach = 3f;
    Interactable currentInteractable;

    [SerializeField] private InputActionProperty gripAnim;
    void Update()
    {
        float gripvalue = gripAnim.action.ReadValue<float>();
        
        CheckInteraction();
        if(gripvalue >= .8f && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }


    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
        if(Physics.Raycast(ray, out hit, playerReach)) 
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    if (newInteractable.enabled)
                    {
                        SetNewCurrentInteractable(newInteractable);
                    }
                    else
                    {
                        DisableInteractable();
                    }
                }
            }
            else
            {
                DisableInteractable();
            }
        }
        else
        {
            DisableInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();


    }

    private void DisableInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.disableOutline();
            currentInteractable = null;
        }
    }
}
