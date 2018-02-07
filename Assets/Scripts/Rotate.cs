using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Vector3 rotation;
	// Use this for initialization
	void Update ()
    {
        transform.Rotate(rotation);
	}
}
