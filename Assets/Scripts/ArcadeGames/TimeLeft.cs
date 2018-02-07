using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLeft : MonoBehaviour {

    public float timeLeft;
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            GameManager.current.GetNextGame();
	}
}
