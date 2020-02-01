using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class JunkSlotDisplay : MonoBehaviour
{
    public enum eJunkSlotStatus
    {
        Filled,
        Empty
    }
    private eJunkType MyJunkType;
    private eJunkSlotStatus MySlotStatus;
    private SpriteRenderer MySpriteRenderer;

    void Start()
    {
        UpdateSprite();
    }
    public void SetJunkType(eJunkType JunkType)
    {
        MyJunkType = JunkType;
        UpdateSprite();
    }

    public void SetSlotStatus(eJunkSlotStatus NewStatus)
    {
        MySlotStatus = NewStatus;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (MySpriteRenderer == null)
        {
            MySpriteRenderer = GetComponent<SpriteRenderer>();
        }
        JunkSlotDataAccessor Accessor = JunkSlotDataAccessor.GetInstance();
        switch(MySlotStatus)
        {
        case eJunkSlotStatus.Filled:
            MySpriteRenderer.sprite = Accessor.GetDefinitionByType(MyJunkType).FullSprite;
            break;
        case eJunkSlotStatus.Empty:
            MySpriteRenderer.sprite = Accessor.GetDefinitionByType(MyJunkType).EmptySprite;
            break;
        }
    }
}
