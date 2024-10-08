using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragObject : MonoBehaviour
{
    public Transform handTransform; // The VR hand or controller
    public float dragForce = 20f;   // How strong the drag should be
    public float distanceThreshold = 1f;  // Max distance from hand to "snap" the bed

    private Rigidbody rb;
    private bool isDragging = false;

    float Leftgripvalue;
    float Rightgripvalue;
    private bool inTrigger = false;

    [SerializeField] private InputActionProperty leftGrip;
    [SerializeField] private InputActionProperty rightGrip;
    
    private enum CurrentHand
    {
        LEFT,
        RIGHT
    }
    private CurrentHand currentHand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //start dragging
        if (inTrigger)
        {
            if (Leftgripvalue > .8)
            {
                currentHand = CurrentHand.LEFT;
                StartDragging();
            }
            else if (Rightgripvalue > .8)
            {
                currentHand = CurrentHand.RIGHT;
                StartDragging();
            }
        }

        //stop dragging
        if (currentHand == CurrentHand.LEFT && Leftgripvalue < .1)
        { 
            StopDragging();
        }
        else if (currentHand == CurrentHand.RIGHT && Rightgripvalue < .1)
        { 
            StopDragging();
        }
        
        if (isDragging)
        {
            DragObjectWithForce();
        }
    }

    public void StartDragging()
    {
        isDragging = true;
    }

    public void StopDragging()
    {
        isDragging = false;
        rb.velocity = Vector3.zero;  // Stop movement when dragging stops
    }

    private void DragObjectWithForce()
    {
        Vector3 direction = (handTransform.position - transform.position).normalized;
        float distance = Vector3.Distance(handTransform.position, transform.position);
        Debug.Log(distance);

        if (distance > distanceThreshold)
        {
            rb.AddRelativeForce(direction * dragForce, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == handTransform)
        {
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == handTransform)
        {
            inTrigger = false;
        }
    }

    private void Update()
    {
        Leftgripvalue = leftGrip.action.ReadValue<float>();
        Rightgripvalue = rightGrip.action.ReadValue<float>();

        Debug.Log(Leftgripvalue);
        Debug.Log(Rightgripvalue);
    }
}
