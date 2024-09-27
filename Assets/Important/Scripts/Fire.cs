using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator fireAnim;
    void Start()
    {
        if (fireAnim != null)
        {
            fireAnim.Play("FireMoving");
        }
    }
}
