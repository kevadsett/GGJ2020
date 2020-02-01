using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerId : MonoBehaviour
{
    static public int NextPlayerId = 0;
    
    public int Id { get; private set; }

    void Start()
    {
        Id = NextPlayerId++;
        //Debug.Log("Player spawned with ID: " + Id);
    }
}
