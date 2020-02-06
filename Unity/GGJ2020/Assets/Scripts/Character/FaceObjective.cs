using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObjective : MonoBehaviour
{
    public Transform objTForm;
    
    void Update()
    {
        transform.localScale = Vector3.one * ((transform.parent.GetComponent<junkInteraction>().isCarrying) ? 1 : 0);

        transform.up = (objTForm.position - transform.position).normalized;
    }
}
