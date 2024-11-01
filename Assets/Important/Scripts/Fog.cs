using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem fog;
    private float fogAlpha;
    private int time = 0;
    private float alphaBySec = 0.004f;//1.02f;
    private int maxTime = 90;
    private Color color;
    void Start()
    {
        fog = GetComponent<ParticleSystem>();
        color = fog.main.startColor.color;
    }
    void FixedUpdate()
    {
        var main = fog.main;
        if (time < (int)Time.time && time < maxTime)
        {
            color.a += alphaBySec;
            main.startColor = new ParticleSystem.MinMaxGradient(color);
            time = (int)Time.time;
            //Debug.Log(time);
        }
    }
}
