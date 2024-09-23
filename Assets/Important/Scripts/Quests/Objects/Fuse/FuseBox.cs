using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : QuestObject
{
    [SerializeField] private FuseDoor fuseDoor;
    private bool isOn = true;
    private void Start()
    {
        questObject = QuestManager.TargetObject.Electricity;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand") && fuseDoor.isOpen)
        {
            isOn = !isOn;
            if(!isOn) QuestManager.questManager.AddQuestProgress(questID, 1);
            else
            {
                QuestManager.questManager.AddQuestProgress(questID, -1);
            }
        }
    }
}
