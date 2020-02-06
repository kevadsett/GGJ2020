using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSelecta : MonoBehaviour
{
    public CharacterMovement.eState state;
    public GameObject[] faces;

    void Update()
    {
        for (int i = 0; i < faces.Length; i++)
        {
            faces[i].SetActive (i == (int) state);
        }
    }
}
