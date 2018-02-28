using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private VerticalMove vertical;
    public bool useVelocity = false;
    public float power;
    
void Start()
	{
		vertical = GetComponent<VerticalMove>();
        if (useVelocity)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * power;
        }
    }
	// Update is called once per frame
	void Update () 
	{
		if(vertical)
			vertical.Move(1);

        
    }
}
