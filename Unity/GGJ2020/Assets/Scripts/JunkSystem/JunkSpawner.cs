using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : MonoBehaviour
{
    public float RandomDelayMin = 0.5f;
    public float RandomDelayMax = 5f;

    public float HorizontalSpread = 2f;
    public float VerticalSpread = 2f;

    public int MaxSpawnedJunkCount = 5;

    public GameObject JunkPrefab;

    private float SpawnTimer;
    private float NextSpawnDelay;

    private int SpawnedJunkCount;

    private eJunkType LastSpawnedJunkType;
    private int JunkTypeCount;
    void Start()
    {
        NextSpawnDelay = Random.Range(RandomDelayMin, RandomDelayMax);
        JunkMachine.JunkSlottedEvent.AddListener(OnJunkSlotted);
        JunkTypeCount = System.Enum.GetNames(typeof(eJunkType)).Length;
        LastSpawnedJunkType = (eJunkType)Random.Range(0, JunkTypeCount);
    }
    void Update()
    {
        SpawnTimer += Time.deltaTime;
        if (SpawnedJunkCount >= MaxSpawnedJunkCount)
        {
            return;
        }

        if (SpawnTimer >= NextSpawnDelay)
        {
            GameObject CurrentJunkObject = GameObject.Instantiate(JunkPrefab, new Vector3(
                (Random.value * 2f - 1) * HorizontalSpread,
                (Random.value * 2f - 1) * VerticalSpread,
                0),
                Quaternion.identity,
                transform);

            int RandomIncrementOffset = Random.Range(-1, 1);
            JunkBehaviour CurrentJunkBehaviour = CurrentJunkObject.GetComponent<JunkBehaviour>();
            int NextSpawnedJunkTypeInt = ((int)LastSpawnedJunkType + RandomIncrementOffset + JunkTypeCount) % JunkTypeCount;
            CurrentJunkBehaviour.SetJunkType((eJunkType)NextSpawnedJunkTypeInt);
            LastSpawnedJunkType = (eJunkType)NextSpawnedJunkTypeInt;

            NextSpawnDelay = Random.Range(RandomDelayMin, RandomDelayMax);
            SpawnTimer = 0;
            SpawnedJunkCount++;
        }
    }
    private void OnJunkSlotted()
    {
        SpawnedJunkCount--;
    }
}
