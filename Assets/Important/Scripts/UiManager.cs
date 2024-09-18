using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    public GameObject image;

    private void Start()
    {
       // Window.OnWindowCompleted += EnableImage;
    }

    private void EnableImage()
    {
        image.SetActive(true);
    }
}
