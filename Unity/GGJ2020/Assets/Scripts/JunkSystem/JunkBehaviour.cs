using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public eJunkType JunkType { get; private set; }
    public JunkDisplay MyJunkSlotDisplay;
    public bool BeingCarried;
    
    void Start()
    {
        MyJunkSlotDisplay.SetJunkType(JunkType);
    }

    public void SetJunkType(eJunkType NewType)
    {
        JunkType = NewType;
        if (MyJunkSlotDisplay)
        {
            MyJunkSlotDisplay.SetJunkType(JunkType);
        }
    }
}
