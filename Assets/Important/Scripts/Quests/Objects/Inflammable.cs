using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inflammable : QuestObject
{
    // public static event Action OnInflammableCompleted;
    // public static event Action OnInflammableUncompleted;
    private void Start()
    {
        questObject = QuestManager.TargetObject.Inflammable;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bed") || other.gameObject.CompareTag("Couch"))
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bed") || other.gameObject.CompareTag("Couch"))
        {
            QuestManager.questManager.AddQuestProgress(questID, -1);
        }
    }
}
