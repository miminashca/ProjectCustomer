using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    //[SerializeField] private CharacterController player;
    private PlayerMovement player;

    private Color color;
    private float colorIntensity = 0.1f;
    private Color cyan = new Color(1, 191, 165, 255);
    private Color white = new Color(255, 255, 255, 255);
    
    private float maxDistance = 10f;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        
        if (Distance(player) <= maxDistance)
        {
            color = cyan;
        }
        else
        {
            color = white;
        }
    }
    void Update()
    {
        CheckDistance(player);
        Debug.Log(Distance(player));
    }
    private void CheckDistance(PlayerMovement other)
    {
        float proportion = 1.1f - ((Distance(other) / maxDistance));
        if (Distance(other) <= maxDistance)
        {
            ChangeColor(color, cyan, proportion);
            colorIntensity = 0.1f * proportion;
        }
        if (Distance(other) > maxDistance)
        {
            ChangeColor(color, white, -proportion);
            colorIntensity = 0.01f;
        }
        outlineMaterial.SetColor("_OutlineColor", color*colorIntensity);
    }
    private float Distance(PlayerMovement other)
    {
        Vector2 location = new Vector2(transform.position.x, transform.position.z);
        Vector2 otherLocation = new Vector2(other.transform.position.x, other.transform.position.z);
        
        return Vector2.Distance(location, otherLocation);
    }
    private void ChangeColor(Color colorA, Color colorB, float time)
    {
        color = Color.Lerp(colorA, colorB, time);
    }
}
