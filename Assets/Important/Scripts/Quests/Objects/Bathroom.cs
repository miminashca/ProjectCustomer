using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : QuestObject
{
    private bool isInBathroom = false;
    private void Start()
    {
        questObject = QuestManager.TargetObject.Bathroom;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) isInBathroom = !isInBathroom;
        //Debug.Log(isInBathroom);
        
        if (isInBathroom)
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
        }
        else
        {
            QuestManager.questManager.AddQuestProgress(questID, -1);
        }
    }
    
}
