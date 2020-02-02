using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JunkMachine : MonoBehaviour
{
    [System.Serializable]
    public class JunkRequirement
    {
        public List<eJunkType> JunkTypeList;
    }

    [System.Serializable]
    public class JunkRequirementList
    {
        public List<JunkRequirement> List;
    }
    
    [System.Serializable]
    public class MyIntEvent : UnityEvent<int>
    {
    }
    public static UnityEvent<int> RequirementsMetEvent = new MyIntEvent();

    public static UnityEvent JunkSlottedEvent = new UnityEvent();

    public int MachineId;

    public float SlotSpreadAngleDegrees = 180f;

    public Transform JunkDisplayPointCentre;

    public GameObject JunkTypeDisplayPrefab;

    public JunkRequirementList PossibleJunkRequirements;
    JunkRequirement MyJunkRequirement;
    private Dictionary<eJunkType, List<JunkSlotDisplay>> JunkSlotDisplayInstances;
    
    private int CurrentlyMetRequirements;
    void Start()
    {
        JunkSlotDisplayInstances = new Dictionary<eJunkType, List<JunkSlotDisplay>>();
        
        MyJunkRequirement = PossibleJunkRequirements.List[Random.Range(0, PossibleJunkRequirements.List.Count)];
        
        float SlotSpreadAngleRadians = SlotSpreadAngleDegrees / 180 * Mathf.PI;

        for(int i = 0; i < MyJunkRequirement.JunkTypeList.Count; i++)
        {
            float position = i/(float)(MyJunkRequirement.JunkTypeList.Count - 1);
           // Debug.Log(position);

            position *= SlotSpreadAngleRadians;
            position -= SlotSpreadAngleRadians / 2f;
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

        if (MyJunkRequirement.JunkTypeList.Contains(Type) == false)
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
            CurrentlyMetRequirements++;
            JunkSlottedEvent.Invoke();
            if (CurrentlyMetRequirements == MyJunkRequirement.JunkTypeList.Count)
            {
                RequirementsMetEvent.Invoke(PlayerId);
            }
            return true;
        }
        return false;
    }

}
