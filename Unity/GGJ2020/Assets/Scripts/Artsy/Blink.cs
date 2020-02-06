using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public float blinkDuration;
    public GameObject[] Blinkables;

    float timer;
    bool isBlinking;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f) {
            isBlinking = !isBlinking;
            timer = isBlinking ? blinkDuration : Random.Range (minTime, maxTime);

            for (int i = 0; i < Blinkables.Length; i++)
                Blinkables[i].SetActive (!isBlinking);
        }
    }
}
