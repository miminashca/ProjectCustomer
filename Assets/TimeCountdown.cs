using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
public class TimeCountdown : MonoBehaviour
{
    [SerializeField] Image black;
    [SerializeField] Animator fade;
    [SerializeField] TMP_Text timerText;

    [SerializeField] float timeRemaining;

    bool nextSceneLoading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
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
    }

    IEnumerator Fading()
    {
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(1);
        
    }
}
