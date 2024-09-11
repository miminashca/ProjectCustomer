using Palmmedia.ReportGenerator.Core.Reporting.Builders;
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
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(FireExOn)
        {
            this.transform.position = new Vector3(PlayHead.transform.position.x, PlayHead.transform.position.y + 2, PlayHead.transform.position.y);
            this.transform.rotation = PlayHead.transform.rotation;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHead") && this.CompareTag("Mask"))
        {
            currentItem.SetActive(false);
            maskOn = true;
        }
        if (other.CompareTag("PlayerHead") && this.CompareTag("FireEx"))
        {
            FireExOn = true;
            PlayHead = other.gameObject;
            this.GetComponentInChildren<CapsuleCollider>().enabled = false;
        }
    }
}
