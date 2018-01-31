using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public string axisName;
	public GameObject bullet;
	public Transform fireTransform;
	public float fireRate;
	private float currentTime;
	
	public void Fire()
	{
		if(currentTime < fireRate) return;
		currentTime = 0;
		GameObject shooty = (GameObject)Instantiate(bullet, fireTransform.position, fireTransform.rotation);
		shooty.GetComponent<RemoveAfterHit>().sender = gameObject;
        shooty.GetComponent<RemoveAfterHit>().doDamage = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentTime += Time.deltaTime;
		if(Input.GetAxisRaw(axisName) == 1)
		{
			Fire();
		}
	}
}
