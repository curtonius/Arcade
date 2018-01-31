using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesData : MonoBehaviour
{
    private Text livesText;
    // Use this for initialization
    void Start()
    {
        livesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.current.playing)
            livesText.text = "";
        else
            livesText.text = "LIVES: " + GameManager.lives.ToString();
    }
}
