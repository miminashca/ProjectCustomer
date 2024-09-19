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
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag == "Player" && timer>=treshold)
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
      }
   }

   private void FixedUpdate()
   {
      timer += Time.deltaTime;
   }
}
