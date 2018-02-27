using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleCatcher : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(5,15), 0);
            other.GetComponent<Rigidbody>().useGravity = true;
        }
        /*Jump jump = other.GetComponentInParent<Jump>();
        if (jump)
        {
            Debug.Log("JUMP");
            jump.jumpHeight += Random.Range(0, 10);
            jump.JumpUp();
        }*/
    }
}
