using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Airconditioner : QuestObject
{
    public Switch onOffSwitch;
    
    public static event Action OnConditionerCompleted;
    public static event Action OnConditionerUncompleted;
    private void Awake()
    {
        questObject = QuestManager.TargetObject.Airconditioning;
        onOffSwitch.questObject = questObject;
    }
    private void Start()
    {
        Switch.OnConditionerActivate += AddProgress;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
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
    
    private void Update()
    {
        if (QuestManager.questManager.CheckCompletedQuest(questID))
        {
            OnConditionerCompleted?.Invoke();
            //Debug.Log(QuestManager.questManager.questList[questID].progress);
        }
        if (QuestManager.questManager.CheckUncompletedQuest(questID))
        {
            OnConditionerUncompleted?.Invoke();
            //Debug.Log(QuestManager.questManager.questList[questID].progress);
        }
    }
}
