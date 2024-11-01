using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ReadSuccessRate : MonoBehaviour
{
    private QuestManager manager;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;

    [Header ("Scores lower than 20")]

    [SerializeField] private string lowScoreText1;
    [SerializeField] private string LowScoreText2;

    [Header("Scores between 20 and 40")]

    [SerializeField] private string LowMidScoreText1;
    [SerializeField] private string LowMidScoreText2;

    [Header("Scores between 40 and 60")]

    [SerializeField] private string MidScoreText1;
    [SerializeField] private string MidScoreText2;

    [Header("Scores between 60 and 80")]

    [SerializeField] private string MidHighScoreText1;
    [SerializeField] private string MidHighScoreText2;

    [Header("Scores between 80 and 100")]

    [SerializeField] private string HighScoreText1;
    [SerializeField] private string HighScoreText2;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<QuestManager>();
        float score = manager.successRate;
        if (score > 0 && score < 20)
        {
            text1.text = lowScoreText1;
            text2.text = LowScoreText2;
        }
        if(score >= 20 && score <40)
        {
            text1.text = LowMidScoreText1;
            text2.text = LowMidScoreText2;
        }
        if(score >= 40 && score < 60)
        {
            text1.text = MidScoreText1;
            text2.text = MidScoreText2;
        }
        if(score >= 60 && score < 80)
        {
            text1.text = MidHighScoreText1;
            text2.text = MidHighScoreText2;
        }
        if(score >= 80)
        {
            text1.text = HighScoreText1;
            text2.text = HighScoreText2;
        }
    }


}
