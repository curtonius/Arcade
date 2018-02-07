using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour {

    public GameObject obj;
    public Vector3 min;
    public Vector3 max;
    public int maxObjects;

    public bool spawnOverTime;
    public float timeBetweenSpawns;

    private float currentTime;
	// Use this for initialization
	void Start ()
    {
		for(int i=0; i<maxObjects; ++i)
        {
            Instantiate(obj, new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)),Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!spawnOverTime) return;
        currentTime += Time.deltaTime;

        if(currentTime >=timeBetweenSpawns)
        {
            currentTime = 0;
            Instantiate(obj, new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)), Quaternion.identity);
        }
	}
}
