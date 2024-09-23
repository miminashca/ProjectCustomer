
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class ItemEquip : MonoBehaviour
{
    [SerializeField] bool maskOn;
    [SerializeField] bool FireExOn;

    [SerializeField] GameObject currentItem;
    [SerializeField] GameObject PlayHead;
    void Update()
    {
        if(FireExOn)
        {
            this.transform.position = new Vector3(PlayHead.transform.position.x + .2f, PlayHead.transform.position.y + 1f, PlayHead.transform.position.z);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHead") && this.name == "N95Mask")
        {
            currentItem.SetActive(false);
            maskOn = true;
        }
        if (other.CompareTag("PlayerHead") && this.name == "FireEx")
        {
            FireExOn = true;
            PlayHead = other.gameObject;
            this.GetComponentInChildren<CapsuleCollider>().enabled = false;
        }
    }
}
