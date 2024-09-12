using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty pinchAnim;
    [SerializeField] private InputActionProperty gripAnim;

    public Animator handAnimator;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float gripvalue = gripAnim.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripvalue);

        float triggervalue = pinchAnim.action.ReadValue < float>();
        handAnimator.SetFloat("Trigger", triggervalue);
       
        

       
    }
}
