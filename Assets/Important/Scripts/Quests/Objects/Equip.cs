using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : QuestObject
{ 
    public QuestManager.TargetObject questObject1;
    private void Start()
    {
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHead"))
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
            Destroy(gameObject);
        }
    }
}
