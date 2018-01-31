using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	private RaycastHit floorHit;
	private Ray camRay;
	private Rigidbody rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate () 
	{
		camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        if(Physics.Raycast (camRay, out floorHit, 100.0f))
        {
            if (floorHit.transform != null && floorHit.transform.tag == "Player") return;
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            rb.MoveRotation (newRotation);
        }
	}
}
