using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float DistanceUntilStep = 1f;
    [SerializeField] private AudioClip[] clips;
    private AudioSource source;
    private Vector3 lastLocation;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(lastLocation, transform.position) > DistanceUntilStep && source != null)
        {
            lastLocation = transform.position;
            AudioClip randomClip = clips[Random.Range(0, clips.Length)];
            source.PlayOneShot(randomClip);
            
        }
    }
}
