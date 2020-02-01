using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public eJunkType JunkType;
    public SpriteRenderer JunkSlotSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        JunkSlotDataAccessor Accessor = JunkSlotDataAccessor.GetInstance();
        JunkSlotSpriteRenderer.sprite = Accessor.GetDefinitionByType(JunkType).Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
