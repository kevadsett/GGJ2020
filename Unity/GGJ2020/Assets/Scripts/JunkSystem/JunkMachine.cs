using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkMachine : MonoBehaviour
{
    public int JunkRequirementCount;

    public Transform JunkDisplayPointCentre;

    public GameObject JunkTypeDisplayPrefab;
    private List<eJunkType> JunkRequirements = new List<eJunkType>();
    private List<JunkSlotDisplay> JunkTypeDisplayInstances = new List<JunkSlotDisplay>();
    
    void Start()
    {
        for(int i = 0; i < JunkRequirementCount; i++)
        {
            float position = i/(float)(JunkRequirementCount - 1);

            position *= Mathf.PI;
            position -= Mathf.PI / 2f;
            GameObject JunkTypeDisplayObject = GameObject.Instantiate(
                JunkTypeDisplayPrefab, new Vector3(
                JunkDisplayPointCentre.position.x + Mathf.Sin(position),
                JunkDisplayPointCentre.position.y + Mathf.Cos(position),
                JunkDisplayPointCentre.position.z),
                JunkDisplayPointCentre.rotation,
                JunkDisplayPointCentre);

            JunkSlotDisplay CurrentJunkTypeDisplay = JunkTypeDisplayObject.GetComponent<JunkSlotDisplay>();

            eJunkType CurrentRequirement = (eJunkType)Random.Range(0, 3);
            CurrentJunkTypeDisplay.SetJunkType(CurrentRequirement);
            CurrentJunkTypeDisplay.SetSlotStatus(JunkSlotDisplay.eJunkSlotStatus.Empty);

            JunkRequirements.Add(CurrentRequirement);
            JunkTypeDisplayInstances.Add(CurrentJunkTypeDisplay);
        }
    }

}
