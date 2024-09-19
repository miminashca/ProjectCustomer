using System;
using UnityEngine;

public class Window : QuestObject
{
    private bool windowIsActive = true;
    //public static event Action OnWindowCompleted;
    private Animator animator;
    
    private void Start()
    {
        questObject = QuestManager.TargetObject.Window;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
        
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && windowIsActive)
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
            animator.Play("WindowClose");
            windowIsActive = false;
        }
    }

    // private void Update()
    // {
    //     if (QuestManager.questManager.CheckCompletedQuest(questID))
    //     {
    //         OnWindowCompleted?.Invoke();
    //         //Debug.Log(QuestManager.questManager.questList[questID].progress);
    //     }
    // }
}
