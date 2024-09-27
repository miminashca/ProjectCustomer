using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : QuestObject
{
    private Light lightSource;
    private Switch lightSwitch;

    private void Awake()
    {
        lightSource = GetComponentInChildren<Light>();
        lightSwitch = GetComponentInChildren<Switch>();
        if(lightSwitch != null && !lightSwitch.isOn)
        {
            lightSource.enabled = false;
        }
    }
    private void Start()
    {
        questObject = QuestManager.TargetObject.Light;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);



        lightSwitch.questObject = questObject;


        Switch.OnLightActivate += AddProgress;
    }
    private void AddProgress()
    {
        if (!lightSwitch.isOn)
        {
            QuestManager.questManager.AddQuestProgress(questID, -1);
            lightSource.enabled = false;
        }
        else if (lightSwitch.isOn)
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
            lightSource.enabled = true;
        }
    }
    private void OnDestroy()
    {
        Switch.OnLightActivate -= AddProgress;
    }
}
