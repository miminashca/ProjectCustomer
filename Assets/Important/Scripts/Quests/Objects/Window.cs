using System;
using UnityEngine;

public class Window : QuestObject
{
    private bool isOpen = true;
    //public static event Action OnWindowCompleted;
    private Animator animator;
    private AudioSource closeSound;
    private float treshold = 1.5f;
    private float time = 0f;
    
    private void Start()
    {
        questObject = QuestManager.TargetObject.Window;
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
        closeSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand" && time >= treshold)
        {
            time = 0f;
            if (isOpen)
            {
                QuestManager.questManager.AddQuestProgress(questID, 1);
                animator.Play("CloseWindow");
                closeSound.Play();
                isOpen = false;
            }
            if (!isOpen)
            {
                QuestManager.questManager.AddQuestProgress(questID, -1);
                animator.Play("OpenWindow");
                closeSound.Play();
                isOpen = true;
            }
        }
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        // if (QuestManager.questManager.CheckCompletedQuest(questID))
        // {
        //     OnWindowCompleted?.Invoke();
        //     //Debug.Log(QuestManager.questManager.questList[questID].progress);
        // }

    }
}
