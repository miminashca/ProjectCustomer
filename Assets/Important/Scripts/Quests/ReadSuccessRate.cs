using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ReadSuccessRate : MonoBehaviour
{
    private QuestManager manager;
    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;
    private TextMeshProUGUI text3;

    

    [Header ("Scores lower than 20")]

    [SerializeField] private string lowScoreText1;
    [SerializeField] private string LowScoreText2;
    [SerializeField] private string LowScoreText3;

    [Header("Scores between 20 and 40")]

    [SerializeField] private string LowMidScoreText1;
    [SerializeField] private string LowMidScoreText2;
    [SerializeField] private string LowMidScoreText3;

    [Header("Scores between 40 and 60")]

    [SerializeField] private string MidScoreText1;
    [SerializeField] private string MidScoreText2;
    [SerializeField] private string MidScoreText3;

    [Header("Scores between 60 and 80")]

    [SerializeField] private string MidHighScoreText1;
    [SerializeField] private string MidHighScoreText2;
    [SerializeField] private string MidHighScoreText3;

    [Header("Scores between 80 and 100")]

    [SerializeField] private string HighScoreText1;
    [SerializeField] private string HighScoreText2;
    [SerializeField] private string HighScoreText3;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<QuestManager>();
        float score = manager.successRate;
        if (score > 0 && score < 20)
        {
            text1.text = lowScoreText1;
            text2.text = LowScoreText2;
            text3.text = LowScoreText3;
        }
        if(score >= 20)
        {

        }
    }


}
