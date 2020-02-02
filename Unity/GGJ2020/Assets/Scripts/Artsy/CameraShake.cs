using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public AnimationCurve curve;
    public float strength;
    public float speed;

    static CameraShake instance;
    Vector3 centrePos;
    Vector3 shakePos;
    float timer = 1f;

    void Awake()
    {
        instance = this;
        centrePos = transform.localPosition;
    }

    void Update ()
    {
        timer += Time.deltaTime;
        transform.localPosition = Vector3.Lerp (centrePos, shakePos, curve.Evaluate(timer * speed));
    }

    void DirShake(Vector3 dir)
    {
        timer = 0f;
        shakePos = centrePos + dir.normalized * strength;
    }

    public static void Shake(Vector3 dir)
    {
        if (instance != null) instance.DirShake (dir);
    }
}
