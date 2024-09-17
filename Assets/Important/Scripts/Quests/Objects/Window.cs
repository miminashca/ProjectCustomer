using System;
using UnityEngine;

public class Window : MonoBehaviour
{
    private QuestManager.TargetObject questObject = QuestManager.TargetObject.Window;
    private int questID;
    
    private bool windowIsActive = true;
    
    public static event Action OnQuestCompleted;
    private void Start()
    {
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && windowIsActive)
        {
            QuestManager.questManager.AddQuestProgress(questID, 1);
            windowIsActive = false;
        }
    }

    private void Update()
    {
        if (QuestManager.questManager.CheckCompletedQuest(questID))
        {
            OnQuestCompleted?.Invoke();
            QuestManager.questManager.CloseQuest(questID);
            //Debug.Log(QuestManager.questManager.questList[questID].progress);
        }
    }
}
