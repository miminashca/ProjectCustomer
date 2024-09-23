using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
   public bool isOn = false;
   private float treshold = 1.5f;
   private float timer = 1.5f;
   
   
   [NonSerialized] public QuestManager.TargetObject questObject;

   public static event Action OnConditionerActivate;
   public static event Action OnLightActivate;
   [SerializeField] private AudioSource soundOn;
   [SerializeField] private AudioSource soundOff;
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag == "PlayerHand" && timer>=treshold)
      {
         isOn = !isOn;
         // Debug.Log(isOn);
         // Debug.Log(timer);
         timer = 0f;

         if (questObject == QuestManager.TargetObject.Airconditioning)
         {
            OnConditionerActivate?.Invoke();
         }
         if (questObject == QuestManager.TargetObject.Light)
         {
            OnLightActivate?.Invoke();
         }
         if (isOn)
         {
            if(soundOn != null)
            {
                soundOn.Play();
            }
         }
         else
         {
            if(soundOff != null)
            {
                soundOff.Play();
            }
         }
      }
   }

   private void FixedUpdate()
   {
      timer += Time.deltaTime;
   }
}
