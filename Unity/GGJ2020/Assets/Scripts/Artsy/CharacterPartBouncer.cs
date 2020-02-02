using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPartBouncer : MonoBehaviour
{
    public float speed;
    public float timeOffset;
    public Vector3 bounceVec;
    
    Vector3 offset;
    Transform tform;

    bool playAnim;

    void Awake ()
    {
        tform = GetComponent<Transform> ();
        offset = tform.localPosition;
    }

    void Update()
    {
        if (playAnim) tform.localPosition = offset + bounceVec * Mathf.Abs (Mathf.Sin (timeOffset + Time.time * speed));
        else tform.localPosition = offset;
    }

    public void UpdateBounciness (Vector3 moveVec)
    {
        playAnim = moveVec.magnitude > 0.1f;
    }
}