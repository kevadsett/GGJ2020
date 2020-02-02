using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Vector3 movementVec;
    public float maxAnimSpeed;
    public CharacterPartDirOffset[] offsettableParts;
    public CharacterPartBouncer[] bounceableParts;

    Vector3 offsetVec;

    void LateUpdate()
    {
        Vector3 delta = movementVec.normalized - offsetVec;
        float magnitude = Mathf.Min (delta.magnitude, maxAnimSpeed * Time.deltaTime);

        offsetVec += delta.normalized * magnitude;

        for (int i = 0; i < offsettableParts.Length; i++)
        {
            offsettableParts[i].OffsetUpdate (offsetVec);
        }

        for (int i = 0; i < bounceableParts.Length; i++)
        {
            bounceableParts[i].UpdateBounciness (movementVec);
        }
    }
}
