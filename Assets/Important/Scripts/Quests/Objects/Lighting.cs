using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : QuestObject
{
    private Light lightSource;
    private Switch lightSwitch;
    private void Start()
    {
        questObject = QuestManager.TargetObject.Light;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);

        lightSource = GetComponentInChildren<Light>();
        lightSwitch = GetComponentInChildren<Switch>();

        lightSwitch.questObject = questObject;
        lightSource.enabled = false;

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
