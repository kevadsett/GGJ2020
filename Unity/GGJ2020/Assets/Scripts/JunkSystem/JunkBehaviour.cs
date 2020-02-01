using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public static int DEBUG_ID = 0;
    private int MyId;
    public eJunkType JunkType { get; private set; }
    public GameObject JunkSlotDisplayPrefab;

    private JunkSlotDisplay MyJunkSlotDisplay;
    
    void Start()
    {
        MyId = DEBUG_ID++;
        GameObject MyJunkSlotDisplayObject = GameObject.Instantiate(JunkSlotDisplayPrefab, transform);
        MyJunkSlotDisplay = MyJunkSlotDisplayObject.GetComponent<JunkSlotDisplay>();

        JunkType = (eJunkType)Random.Range(0, 3);

        MyJunkSlotDisplay.SetJunkType(JunkType);
        MyJunkSlotDisplay.SetSlotStatus(JunkSlotDisplay.eJunkSlotStatus.Filled);
    }

    public void SetJunkType(eJunkType NewType)
    {
        JunkType = NewType;
        MyJunkSlotDisplay.SetJunkType(JunkType);
    }
}
