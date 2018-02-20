using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
	}
}
