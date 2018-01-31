using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private VerticalMove vertical;
	void Start()
	{
		vertical = GetComponent<VerticalMove>();
	}
	// Update is called once per frame
	void Update () 
	{
		if(vertical)
			vertical.Move(1);
	}
}
