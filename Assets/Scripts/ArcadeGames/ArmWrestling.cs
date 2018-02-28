using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWrestling : MonoBehaviour {
    public ButtonMash buttonMash;
    public TimeLeft timeLeft;
    private GameObject arms;

    private float dir=0.25f;
    private float currentTime;
    private float moveTime=0.25f;

    private float timeAfterEnd = 5.0f;
    private Quaternion originalRot;
    private bool alreadyAddedPoints;
	// Use this for initialization
	void Start ()
    {
        arms = buttonMash.gameObject;
        originalRot = arms.transform.rotation;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (timeLeft.timeLeft > timeAfterEnd)
        {
            currentTime += Time.deltaTime;
            if (currentTime > moveTime)
            {
                dir *= -1;
                currentTime = 0;
            }

            arms.transform.RotateAround(arms.transform.position, arms.transform.right, dir);
        }
        else
        {
            currentTime += Time.deltaTime;
            buttonMash.done = true;
            if(currentTime < timeAfterEnd)
            {
                if (buttonMash.force >= 10)
                {
                    arms.transform.rotation = originalRot;
                    arms.transform.Rotate(arms.transform.right, 80);
                    if(!alreadyAddedPoints)
                        GameManager.current.AddPoints(100);
                }
                else if (buttonMash.force < 10)
                {
                    arms.transform.rotation = originalRot;
                    arms.transform.Rotate(arms.transform.right, -80);
                    if(!alreadyAddedPoints)
                        GameManager.current.Die();
                }
                alreadyAddedPoints = true;
            }
        }
	}
}
