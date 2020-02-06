using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CharacterPartDirOffset : MonoBehaviour
{
    public float distance;
    
    Vector3 offset;
    Transform tform;

    void Awake ()
    {
        tform = GetComponent<Transform> ();
        offset = tform.localPosition;
    }

    public void OffsetUpdate (Vector3 dir)
    {
        if (tform != null) {
            tform.localPosition = dir * distance + offset;
        }
    }
}
