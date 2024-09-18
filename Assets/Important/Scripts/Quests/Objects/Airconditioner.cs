using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Airconditioner : QuestObject
{
    public Switch onOffSwitch;
    
    // public static event Action OnConditionerCompleted;
    // public static event Action OnConditionerUncompleted;
   
    private void Start()
    {
        questObject = QuestManager.TargetObject.Airconditioning;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
        onOffSwitch.questObject = questObject;
        Switch.OnConditionerActivate += AddProgress;
    }
    private void AddProgress()
    {
        if (!onOffSwitch.isOn)
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
        }
        else if (onOffSwitch.isOn)
        {
            QuestManager.questManager.AddQuestProgress(questID, -1);
        }
        
    }
    private void OnDestroy()
    {
        Switch.OnConditionerActivate -= AddProgress;
    }
}
