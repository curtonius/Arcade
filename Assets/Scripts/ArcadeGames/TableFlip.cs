using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlip : MonoBehaviour
{
    public TimeLeft timeLeft;
    private ButtonMash buttonMash;
    public GameObject table;
    private GameObject newtable;
    private bool launch;
    public Transform characterToShake;
    private int dir = 5;
    // Use this for initialization
    void Start()
    {
        buttonMash = GetComponent<ButtonMash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft.timeLeft == 0 && !launch)
        {
            launch = true;
            GameManager.current.Die();
        }

        if (!launch && buttonMash.force > 10)
        {
            buttonMash.done = true;
            launch = true;
            newtable = Instantiate(table, table.transform.position, Quaternion.Euler(0, 0, 0));
            newtable.transform.parent = null;
            table.SetActive(false);
            Rigidbody rb = newtable.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = new Vector3(buttonMash.force / 2, buttonMash.force / 10, 0);
            
            GameManager.current.AddPoints(100);
            return;
        }

        if(!launch && buttonMash.force > 0)
        {
            characterToShake.RotateAround(characterToShake.position, characterToShake.right, dir);
            dir *= -1;
        }
        if(newtable != null)
            newtable.transform.RotateAround(newtable.transform.position, newtable.transform.forward, -buttonMash.force);
    }
}
