using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObjective : MonoBehaviour
{
    public Transform objTForm;
    
    void Update()
    {
        transform.up = (objTForm.position - transform.position).normalized;
    }
}
