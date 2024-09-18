using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent onInteraction;

    void Start()
    {
        outline = GetComponent<Outline>();
        disableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void disableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
