using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JunkSlotDefinition", menuName = "GGJ2020/JunkSlotDefinition", order = 1)]

public class JunkSlotDefinition : ScriptableObject
{
    public eJunkType Type;
    public Sprite FullSprite;
    public Sprite EmptySprite;
}
