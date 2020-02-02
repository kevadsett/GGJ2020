using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class JunkDisplay : MonoBehaviour
{
    public eJunkType JunkType { get; private set; }
    private SpriteRenderer MySpriteRenderer;
    
    public void SetJunkType(eJunkType JunkType)
    {
        this.JunkType = JunkType;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (MySpriteRenderer == null)
        {
            MySpriteRenderer = GetComponent<SpriteRenderer>();
        }
        JunkSlotDataAccessor Accessor = JunkSlotDataAccessor.GetInstance();
        MySpriteRenderer.sprite = Accessor.GetDefinitionByType(JunkType).JunkSprite;
    }
}
