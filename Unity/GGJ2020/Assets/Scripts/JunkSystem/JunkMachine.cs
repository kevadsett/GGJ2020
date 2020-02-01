using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JunkMachine : MonoBehaviour
{

    public static int NextMachineId = 0;

    [System.Serializable]
    public class MyIntEvent : UnityEvent<int>
    {
    }
    public static UnityEvent<int> RequirementsMetEvent = new MyIntEvent();

    public int MachineId;
    public int JunkRequirementCount;

    public Transform JunkDisplayPointCentre;

    public GameObject JunkTypeDisplayPrefab;
    private List<eJunkType> JunkRequirements = new List<eJunkType>();
    private Dictionary<eJunkType, List<JunkSlotDisplay>> JunkSlotDisplayInstances;
    
    void Start()
    {
        MachineId = NextMachineId++;
        JunkSlotDisplayInstances = new Dictionary<eJunkType, List<JunkSlotDisplay>>();
        for(int i = 0; i < JunkRequirementCount; i++)
        {
            float position = i/(float)(JunkRequirementCount - 1);
           // Debug.Log(position);

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

            if (JunkSlotDisplayInstances.ContainsKey(CurrentRequirement))
            {
                JunkSlotDisplayInstances[CurrentRequirement].Add(CurrentJunkTypeDisplay);
            }
            else
            {
                JunkSlotDisplayInstances.Add(CurrentRequirement, new List<JunkSlotDisplay> { CurrentJunkTypeDisplay });
            }
        }
    }

    public bool TrySlotJunk(eJunkType Type, int PlayerId)
    {
        if (PlayerId != MachineId)
        {
            return false;
        }

        if (JunkRequirements.Contains(Type) == false)
        {
            return false;
        }

        foreach (JunkSlotDisplay JunkSlot in JunkSlotDisplayInstances[Type])
        {
            if (JunkSlot.SlotStatus == JunkSlotDisplay.eJunkSlotStatus.Filled)
            {
                continue;
            }

            JunkSlot.SetSlotStatus(JunkSlotDisplay.eJunkSlotStatus.Filled);
            return true;
        }
        return false;
    }

}
