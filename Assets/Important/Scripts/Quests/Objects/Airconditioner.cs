using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Airconditioner : QuestObject
{
    public Switch onOffSwitch;
    [SerializeField] private GameObject sound;
    private Light redGreenLight;
    
    // public static event Action OnConditionerCompleted;
    // public static event Action OnConditionerUncompleted;
   
    private void Start()
    {
        questObject = QuestManager.TargetObject.Airconditioning;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
        onOffSwitch.questObject = questObject;
        redGreenLight = GetComponentInChildren<Light>();
        redGreenLight.color = Color.green;
        Switch.OnConditionerActivate += AddProgress;
    }
    private void AddProgress()
    {
        if (!onOffSwitch.isOn)
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
            redGreenLight.color = Color.red;
            sound.GetComponent<AudioSource>().Stop();
        }
        else if (onOffSwitch.isOn)
        {
            QuestManager.questManager.AddQuestProgress(questID, -1);
            redGreenLight.color = Color.green;
            sound.GetComponent<AudioSource>().Play();
        }
        
    }
    private void OnDestroy()
    {
        Switch.OnConditionerActivate -= AddProgress;
    }
}
