using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discus : MonoBehaviour
{
    public TimeLeft timeLeft;
    private ButtonMash buttonMash;
    public GameObject disc;
    private GameObject newDisc;
    private bool launch;
    private HorizontalMove discMover;
    private float currentTime = 0;
	// Use this for initialization
	void Start () {
        buttonMash = GetComponent<ButtonMash>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timeLeft.timeLeft == 0 && !launch)
        {
            launch = true;
            GameManager.current.Die();
        }

        if(!launch && buttonMash.force > 10)
        {
            buttonMash.done = true;
            launch = true;
            newDisc = Instantiate(disc, disc.transform.position, Quaternion.Euler(0, 0, 0));
            disc.SetActive(false);
            discMover = newDisc.AddComponent<HorizontalMove>();
            discMover.movementSpeed = buttonMash.force;
            Rigidbody rb = newDisc.AddComponent<Rigidbody>();
            rb.useGravity = false;
            newDisc.GetComponent<Collider>().enabled = false;
            newDisc.AddComponent<AutoMove>();
            GameManager.current.AddPoints(100);
            return;
        }
        if(launch && currentTime < 5)
        {
            currentTime += Time.deltaTime;
        }
        else if(launch && currentTime >= 5)
        {
            GameManager.current.GetNextGame();
        }

        transform.RotateAround(transform.position, Vector3.up, buttonMash.force);
    }
}
