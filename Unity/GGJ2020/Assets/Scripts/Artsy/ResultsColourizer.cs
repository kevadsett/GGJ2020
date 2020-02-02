﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsColourizer : MonoBehaviour
{

    public MeshRenderer mrRecolMatA;
    public MeshRenderer mrRecolMatB;
    public SpriteRenderer srRecolSprite;

    public Material[] playerMats;
    public Sprite[] rocketSprites;

    // Start is called before the first frame update
    void Start()
    {
        mrRecolMatA.material = playerMats[PointsSystem.WinningPlayer];
        mrRecolMatB.material = playerMats[PointsSystem.WinningPlayer];
        srRecolSprite.sprite = rocketSprites[PointsSystem.WinningPlayer];
    }
}