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
    public eJunkType JunkType { get; private set; }
    public eJunkSlotStatus SlotStatus { get; private set; }
    private SpriteRenderer MySpriteRenderer;

    void Start()
    {
        UpdateSprite();
    }
    public void SetJunkType(eJunkType JunkType)
    {
        this.JunkType = JunkType;
        UpdateSprite();
    }

    public void SetSlotStatus(eJunkSlotStatus NewStatus)
    {
        SlotStatus = NewStatus;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (MySpriteRenderer == null)
        {
            MySpriteRenderer = GetComponent<SpriteRenderer>();
        }
        JunkSlotDataAccessor Accessor = JunkSlotDataAccessor.GetInstance();
        switch(SlotStatus)
        {
        case eJunkSlotStatus.Filled:
            MySpriteRenderer.sprite = Accessor.GetDefinitionByType(JunkType).FullSprite;
            break;
        case eJunkSlotStatus.Empty:
            MySpriteRenderer.sprite = Accessor.GetDefinitionByType(JunkType).EmptySprite;
            break;
        }
    }
}
