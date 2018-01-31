using UnityEngine;
using System.Collections;

public class HorizontalMove : MonoBehaviour 
{
	public float movementSpeed;
	
	public bool accelerate;
	public float acceleration;
	private float vel;
	private Rigidbody rb;
	
	private float prev;
	private float axis;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	public void Move(float direction)
	{
		if(accelerate)
		{
			if(Mathf.Abs(vel) < movementSpeed)
			{
				vel += direction*acceleration*Time.deltaTime;
			}
		}
		else
			vel = direction*movementSpeed;
		
		rb.position += transform.right*vel*Time.deltaTime;
	}
	
	private void Deccelerate()
	{
        if (vel < -0.25f)
        {
            vel += acceleration * Time.deltaTime;
        }
        else if (vel > 0.25f)
        {
            vel -= acceleration * Time.deltaTime;
        }
        else
            vel = 0;
		
		rb.position += transform.right*vel*Time.deltaTime;
	}
	
	void Update()
	{
		axis = Input.GetAxisRaw("Horizontal");
	}
	
	void FixedUpdate () 
	{
		if(!accelerate)
		{
			if(gameObject.tag == "Player")
				Move(axis);
		}
		else
		{
			float deltaPos = Mathf.Abs(prev-transform.position.x);
			if(deltaPos < 0.001f)
				vel = 0;
			
			prev = transform.position.x;
			if(gameObject.tag == "Player")
			{
				if(axis == 0)
					Deccelerate();
				else
					Move(axis);
			}
			else
				Deccelerate();
		}
	}
}
