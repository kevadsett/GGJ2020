using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public eJunkType JunkType { get; private set; }
    public JunkDisplay MyJunkSlotDisplay;
    
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
