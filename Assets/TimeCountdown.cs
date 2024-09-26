using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeCountdown : MonoBehaviour
{
    [SerializeField] Image black;
    [SerializeField] Animator fade;
    [SerializeField] TMP_Text timerText;

    [SerializeField] TMP_Text popUpText;

    [SerializeField] float timeRemaining;

    float opacity = 1f;
    bool textOnScreen = true;
    bool nextSceneLoading;

    [NonSerialized] public bool leftRoom;

    [SerializeField] private bool secondPart;
    // Start is called before the first frame update
    void Start()
    {
        popUpText.color = Color.white;
        popUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && leftRoom)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if(timeRemaining > 0 && secondPart)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if(timeRemaining <= 0)
        {
            timeRemaining = 0;
            if(nextSceneLoading == false)
            {
                StartCoroutine(Fading());
                nextSceneLoading = true;
            }  
        }
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        popUpText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (textOnScreen && leftRoom)
        {
            //Debug.Log("AIDS");
            popUpText.gameObject.SetActive(true);
            popUpText.color = new Color(1,1,1, opacity);
            opacity -= .01f;
            Debug.Log(opacity);
            if(opacity <= 0)
            {
                textOnScreen = false;
                popUpText.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Fading()
    {
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    
}
