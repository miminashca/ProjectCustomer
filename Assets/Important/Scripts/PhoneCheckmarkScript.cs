using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCheckmarkScript : MonoBehaviour
{
    private Image checkMark;
    [SerializeField] private int ThisID;

    private void Awake()
    {
        checkMark = GetComponent<Image>();
        checkMark.enabled = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        QuestManager.questUpdated += checkOff;
    }

    private void checkOff(bool done, int ID)
    {
        if (done)
        {
            if(ID == ThisID)
            {
                checkMark.enabled = true;

            }
        }
        else
        {
            checkMark.enabled=false;
        }
    }

    private void OnDestroy()
    {
        QuestManager.questUpdated -= checkOff;
    }
}
