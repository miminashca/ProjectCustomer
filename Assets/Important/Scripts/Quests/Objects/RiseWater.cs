using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseWater : QuestObject
{
    [SerializeField] private Animator animator;
    private bool isActive = true;
    private void Start()
    {
        questObject = QuestManager.TargetObject.RiseWater;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand") && isActive)
        {
            if (gameObject.CompareTag("Sink"))
            {
                animator.Play("RisingWater");
            }
            if (gameObject.CompareTag("Bath"))
            {
                animator.Play("RiseWaterBath");
            }

            isActive = false;
            QuestManager.questManager.AddQuestProgress(questID, 1);
        }
    }
}
