using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreData : MonoBehaviour {
    private Text highscoreText;
	// Use this for initialization
	void Start () {
        highscoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponentInParent<GameManager>().playing)
            highscoreText.text = "HIGHSCORE: " + GameManager.HighScore.ToString();
        else
            highscoreText.text = "SCORE: " + GameManager.CurrentScore.ToString();
    }
}
