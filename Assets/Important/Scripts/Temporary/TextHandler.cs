using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;

    private int currentTextID = 0;
    private float opacity = 0;

    [SerializeField] private float opacityIncrements =0.1f;

    private float countdown = 0;

    [SerializeField] private float visibleTime;

    private bool textVisible;

    [SerializeField] bool finalscene;
    void Start()
    {
        foreach (var text in texts)
        {
            text.color = new Vector4(1, 1, 1, 0);
        }

    }
    
    void Update()
    {
        if(currentTextID < texts.Length)
        {
            texts[currentTextID].color = new Vector4(1, 1, 1, opacity);
        }

        if (!textVisible)
        {
            opacity += opacityIncrements;
            
        }

        if(textVisible)
        {
            countdown += Time.deltaTime;

            if (countdown > visibleTime)
            {
                opacity -= opacityIncrements;

                if(opacity < 0)
                {
                    currentTextID ++;
                    textVisible = false;
                    countdown = 0;
                }
            }
        }

        if(opacity >= 1)
        {
            textVisible = true;
           
        }

        if (texts.Length < currentTextID)
        {
            if (finalscene)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }   
    }
}
