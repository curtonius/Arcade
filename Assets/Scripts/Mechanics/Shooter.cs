using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public string axisName;
	public GameObject bullet;
	public Transform fireTransform;
	public float fireRate;
    public bool doDamage = true;
    public GameObject sender;
	private float currentTime;

    
void Start()
    {
        currentTime = fireRate;
        if (!sender)
            sender = gameObject;
    }
    public void Fire()
	{
		if(currentTime < fireRate) return;
		currentTime = 0;
		GameObject shooty = (GameObject)Instantiate(bullet, fireTransform.position, fireTransform.rotation);
		shooty.GetComponent<RemoveAfterHit>().sender = sender;
        shooty.GetComponent<RemoveAfterHit>().doDamage = doDamage;
        shooty.transform.parent = transform.parent;
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
