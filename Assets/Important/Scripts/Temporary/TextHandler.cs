using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TextHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Animator animator;
    private int currentText = -1;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var text in texts)
        {
            text.enabled = false;
        }
        texts[0].enabled = true;
        animator = GetComponent<Animator>();
        animator.SetBool("Fade",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
