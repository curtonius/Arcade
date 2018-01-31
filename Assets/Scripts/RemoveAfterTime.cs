using UnityEngine;
using System.Collections;

public class RemoveAfterTime : MonoBehaviour {

	public float timeBeforeDestroy;
	private float currentTime;
	
	// Update is called once per frame
	void Update () 
	{
		if(currentTime < timeBeforeDestroy)
			currentTime += Time.deltaTime;
		else
			Destroy(gameObject);
	}
}
