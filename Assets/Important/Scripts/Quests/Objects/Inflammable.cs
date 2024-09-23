using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inflammable : QuestObject
{
    // public static event Action OnInflammableCompleted;
    // public static event Action OnInflammableUncompleted;
    private float treshold = 1f;
    private float timeElapsed= 0f;
    private bool inTrigger = true;
    private void Start()
    {
        questObject = QuestManager.TargetObject.Inflammable;
        if(QuestManager.questManager.FindIDbyTargetObject(questObject) >= 0) questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        if (other.gameObject.CompareTag("Bed") || other.gameObject.CompareTag("Couch"))
        {
            timeElapsed = 0f;
            StartCoroutine(AddProgress(1));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        if (other.gameObject.CompareTag("Bed") || other.gameObject.CompareTag("Couch"))
        {
            timeElapsed = 0f;
            StartCoroutine(AddProgress(-1));
        }
    }

    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
    }
    
    IEnumerator AddProgress(int amountOfProgress)
    {
        yield return new WaitForSeconds(treshold);

        if (timeElapsed >= treshold)
        {
            if (amountOfProgress == 1)
            {
                if (!inTrigger)
                {
                    QuestManager.questManager.AddQuestProgress(questID, amountOfProgress);
                }
            }
            if (amountOfProgress == -1)
            {
                if (inTrigger)
                {
                    QuestManager.questManager.AddQuestProgress(questID, amountOfProgress);
                }
            }
            
        }
    }
}
