using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    protected QuestManager.TargetObject questObject;
    [NonSerialized] public int questID;
    private void Start()
    {
        questID = QuestManager.questManager.FindIDbyTargetObject(questObject);
    }
}
