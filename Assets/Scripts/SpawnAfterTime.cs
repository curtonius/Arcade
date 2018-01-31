using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnAfterTime : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public float timeBeforeSpawnMin;
    public float timeBeforeSpawnMax;
    private float timeBeforeSpawn;
    private float currentTime;

    private void Start()
    {
        timeBeforeSpawn = Random.Range(timeBeforeSpawnMin, timeBeforeSpawnMax);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentTime < timeBeforeSpawn)
            currentTime += Time.deltaTime;
        else
        {
            Object.Instantiate(prefabList[Random.Range(0, prefabList.Count)], transform.position, transform.rotation);
            currentTime = 0;
            timeBeforeSpawn = Random.Range(timeBeforeSpawnMin, timeBeforeSpawnMax);
        }
    }
}
