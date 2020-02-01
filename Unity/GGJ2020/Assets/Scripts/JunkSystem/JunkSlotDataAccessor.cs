using System.Collections.Generic;
using UnityEngine;
public class JunkSlotDataAccessor
{
    private static JunkSlotDataAccessor Instance;
    public static JunkSlotDataAccessor GetInstance() {
        if (Instance == null)
        {
            Instance = new JunkSlotDataAccessor();
        }
        return Instance;
    }
    private Dictionary<eJunkType, JunkSlotDefinition> Definitions = new Dictionary<eJunkType, JunkSlotDefinition>();
    public JunkSlotDataAccessor()
    {
        foreach(object Definition in Resources.LoadAll<JunkSlotDefinition>("JunkSlotDefinitions"))
        {
            JunkSlotDefinition CurrentDefinition = (JunkSlotDefinition)Definition;
            Definitions.Add(CurrentDefinition.Type, CurrentDefinition);
        }
    }

    public JunkSlotDefinition GetDefinitionByType(eJunkType type)
    {
        return Definitions[type];
    }
}