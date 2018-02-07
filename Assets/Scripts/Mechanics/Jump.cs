using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jumpHeight;
	public float gravity;
	private float vel;
	private RaycastHit hit;

	public bool IsGrounded()
	{
        Physics.Raycast(transform.position, -transform.up, out hit, 0.85f);
        if (hit.transform != null)
            return true;

        return false;
	}
	
	public void JumpUp()
	{
		vel = jumpHeight;
	}


    void FixedUpdate () 
	{
		if(!IsGrounded())
			vel -= gravity*Time.deltaTime;
		else
			vel = 0;
		
		if(gameObject.tag == "Player")
			if(Input.GetAxisRaw("Jump") == 1 && IsGrounded())
				JumpUp();
			
		transform.position += new Vector3(0,vel*Time.deltaTime,0);
	}
}
