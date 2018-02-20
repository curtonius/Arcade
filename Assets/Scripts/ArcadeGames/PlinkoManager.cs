using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoManager : MonoBehaviour
{
    private int starterScore;
	// Use this for initialization
	void Start ()
    {
        starterScore = GameManager.CurrentScore;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(starterScore != GameManager.CurrentScore)
        {
            GameManager.current.GetNextGame();
        }
	}
}
