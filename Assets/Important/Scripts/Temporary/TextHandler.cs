using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TextHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    private int currentTextID = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var text in texts)
        {
            text.color = new Vector4(1,1,1,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
