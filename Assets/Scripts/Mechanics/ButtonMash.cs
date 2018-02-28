using UnityEngine;
using System.Collections;

public class ButtonMash : MonoBehaviour {

	public float force;
	public float threshold;
	public string axisName;
    public bool done = false;
	private bool ready;

	
	public void Hit()
	{
			ready=false;
			force += threshold*Time.deltaTime;
        Debug.Log(force);
	}
	// Update is called once per frame
	void Update () 
	{
        if (done)
            return;
		if(ready && Input.GetAxisRaw(axisName) == 1)
		{
			Hit();
		}
		else if(Input.GetAxisRaw(axisName) == 0)
		{
			ready = true;
		}
		
		if(force > 0)
			force -= Time.deltaTime;
		if(force < 0)
			force = 0;
	}
}
