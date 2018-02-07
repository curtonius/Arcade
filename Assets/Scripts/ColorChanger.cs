using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
    public Color color;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = color;
	}
}
