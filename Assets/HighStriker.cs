using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighStriker : MonoBehaviour
{
    private ButtonMash buttonMash;
    public TimeLeft timeLeft;
    private GameObject hammer;

    private float dir = 0.25f;
    private float currentTime;
    private float moveTime = 0.25f;

    private float timeAfterEnd = 5.0f;
    private Quaternion originalRot;
    private bool alreadyAddedPoints;

    public GameObject ball;

    void Start()
    {
        buttonMash = GetComponent<ButtonMash>();
        hammer = buttonMash.gameObject;
        originalRot = hammer.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeLeft.timeLeft > timeAfterEnd)
        {
            currentTime += Time.deltaTime;
            if (currentTime > moveTime)
            {
                dir *= -1;
                currentTime = 0;
            }

            hammer.transform.rotation = originalRot;
            hammer.transform.Rotate(0, 0, buttonMash.force);
        }
        else
        {
            currentTime += Time.deltaTime;
            buttonMash.done = true;
            if (currentTime < timeAfterEnd)
            {
                if (buttonMash.force >= 100)
                {
                    hammer.transform.rotation = originalRot;
                    //if (!alreadyAddedPoints)
                    //    GameManager.current.AddPoints(100);

                    ball.GetComponent<Rigidbody>().velocity = new Vector3(0, buttonMash.force/15, 0);
                }
                else
                {
                    hammer.transform.rotation = originalRot;
                    if (!alreadyAddedPoints)
                        GameManager.current.Die();

                    ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
                }
                alreadyAddedPoints = true;
            }
        }
    }
}
