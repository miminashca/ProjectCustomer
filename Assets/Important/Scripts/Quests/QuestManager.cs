using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using AYellowpaper.SerializedCollections;

//keeps track of quests and their progresses
public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;
    
    [SerializedDictionary("QuestID", "Quest")]
    public SerializedDictionary<int, Quest> questList = new SerializedDictionary<int, Quest>(); //MASTER QUEST LIST
    
    public enum TargetObject
    {
        Sink,
        Couch,
        Window,
        Electricity,
        Fuse,
        Gas,
        Mask,
        Airconditioning,
        Bath,
        Bathroom
    };
    
    private void Awake()
    {
        //singleton
        if (questManager == null)
        {
            questManager = this;
        }
        else if (questManager != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //setting quest id depending on its dictionary key
        foreach (KeyValuePair<int, Quest> entry in questList)
        {
            entry.Value.id = entry.Key;
        }
    }

    //BOOL
    
    // public bool CheckNotAvailableQuest(int questID)
    // {
    //     if (questList[questID].progress == Quest.QuestProgress.NOT_AVAILABLE) return true;
    //     return false;
    // }
    public bool CheckAvailableQuest(int questID)
    {
        if (questList[questID].progress == Quest.QuestProgress.AVAILABLE) return true;
        return false;
    }
    public bool CheckAcceptedQuest(int questID)
    {
        if (questList[questID].progress == Quest.QuestProgress.ACCEPTED) return true;
        return false;
    }
    public bool CheckCompletedQuest(int questID)
    {
        if (questList[questID].progress == Quest.QuestProgress.COMPLETED) return true;
        return false;
    }
    public bool CheckUncompletedQuest(int questID)
    {
        if (questList[questID].progress == Quest.QuestProgress.UNCOMPLETED) return true;
        return false;
    }
    // public bool CheckDoneQuest(int questID)
    // {
    //     if (questList[questID].progress == Quest.QuestProgress.DONE) return true;
    //     return false;
    // }
    

    //VOID
    // public void AcceptQuest(int questID)
    // {
    //     if (questList[questID].progress == Quest.QuestProgress.AVAILABLE)
    //     {
    //         //currentQuestList.Add(questID, questList[questID]);
    //         questList[questID].progress = Quest.QuestProgress.ACCEPTED;
    //     }
    // }
    public void AddQuestProgress(int questID, int progressAmountInt)
    {
        if (progressAmountInt>0 && (CheckAvailableQuest(questID) || CheckAcceptedQuest(questID)))
        {
            questList[questID].questObjectiveCount += progressAmountInt;
            
            if (questList[questID].questObjectiveCount >= questList[questID].questObjectiveRequirement)
            {
                CompleteQuest(questID);
            }
        }
        else if (progressAmountInt<0 && CheckCompletedQuest(questID))
        {
            questList[questID].questObjectiveCount += progressAmountInt;
            
            if (questList[questID].questObjectiveCount < questList[questID].questObjectiveRequirement)
            {
                UncompleteQuest(questID);
            }
        }
    }
    private void CompleteQuest(int questID)
    {
        if (CheckAvailableQuest(questID) || CheckAcceptedQuest(questID))
        {
            questList[questID].progress = Quest.QuestProgress.COMPLETED;
            Debug.Log("completed quest: " + questID + ", " + questList[questID].title);
        }
    }
    private void UncompleteQuest(int questID)
    {
        if (CheckCompletedQuest(questID))
        {
            questList[questID].progress = Quest.QuestProgress.UNCOMPLETED;
            questList[questID].progress = Quest.QuestProgress.AVAILABLE;
            Debug.Log("uncompleted quest: " + questID + ", " + questList[questID].title);
        }
    }
    // public void CloseQuest(int questID)
    // {
    //     if (CheckCompletedQuest(questID))
    //     {
    //         questList[questID].progress = Quest.QuestProgress.DONE;
    //     }
    //} //Close the quest after qiving XP reward, (call from quest object scripts)
    
    
    public int FindIDbyTargetObject(TargetObject targetObject)
    {
        foreach (KeyValuePair<int, Quest> entry in questList)
        {
            if (entry.Value.questObject == targetObject)
            {
                return entry.Key;
            }
        }

        return -1;
    } //Get the ID of a certain quest, by the target object (call from quest object scripts)
}
