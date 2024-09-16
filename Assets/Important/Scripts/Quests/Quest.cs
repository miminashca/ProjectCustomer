using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeps all information about a certain quest

[System.Serializable]
public class Quest
{
    public enum QuestProgress
    {
        //NOT_AVAILABLE,
        AVAILABLE,
        ACCEPTED,
        COMPLETED,
        //DONE
    };

    public string title;           //title for the quest
    [NonSerialized] public int id; //ID number of the quest
    public QuestProgress progress; //state of the current quest (enum)
    
    //optional
    // public string description;     //string from our quest Giver/Reciever
    // public string hint;            //string from our quest Giver/Reciever
    // public string congratulation;  //string from our quest Giver/Reciever
    // public string summary;         //string from our quest Giver/Reciever
    
    public int nextQuest;          //the next quest, if there is any (chain quest)
    
    //[NonSerialized] public string questObjective;
    [NonSerialized] public int questObjectiveCount = 0;//current number of quest objective count
    public int questObjectiveRequirement; //required amount of quest objectives (objects)

    public int expReward;
}
