using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : QuestObject
{
    [SerializeField] private Animator animator;
    private bool isActive = true;
    private void Start()
    {
        questObject = QuestManager.TargetObject.Gas;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand") && isActive)
        {
            animator.Play("GasValveTurn");
            isActive = false;
            QuestManager.questManager.AddQuestProgress(questID, 1);
        }
    }
}
