using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public eJunkType JunkType { get; private set; }
    public GameObject JunkSlotDisplayPrefab;

    private JunkSlotDisplay MyJunkSlotDisplay;
    
    void Start()
    {
        GameObject MyJunkSlotDisplayObject = GameObject.Instantiate(JunkSlotDisplayPrefab, transform);
        MyJunkSlotDisplay = MyJunkSlotDisplayObject.GetComponent<JunkSlotDisplay>();

        MyJunkSlotDisplay.SetJunkType(JunkType);
        MyJunkSlotDisplay.SetSlotStatus(JunkSlotDisplay.eJunkSlotStatus.Filled);
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
