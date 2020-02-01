using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public eJunkType JunkType;
    public GameObject JunkSlotDisplayPrefab;
    
    void Start()
    {
        GameObject MyJunkSlotDisplayObject = GameObject.Instantiate(JunkSlotDisplayPrefab, transform);
        JunkSlotDisplay MyJunkSlotDisplay = MyJunkSlotDisplayObject.GetComponent<JunkSlotDisplay>();
        MyJunkSlotDisplay.SetJunkType(JunkType);
        MyJunkSlotDisplay.SetSlotStatus(JunkSlotDisplay.eJunkSlotStatus.Filled);
    }
}
