using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public float volume;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volume;
    }
}
