using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    private VerticalMove verticalMove;
    private HorizontalMove horizontalMove;
	// Use this for initialization
	void Start () {
        verticalMove = GetComponent<VerticalMove>();
        horizontalMove = GetComponent<HorizontalMove>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (verticalMove && verticalMove.movementSpeed > 0)
            verticalMove.Move(1);
        else if (verticalMove && verticalMove.movementSpeed < 0)
            verticalMove.Move(-1);

        if (horizontalMove && horizontalMove.movementSpeed > 0)
            horizontalMove.Move(1);
        else if (horizontalMove && horizontalMove.movementSpeed < 0)
            horizontalMove.Move(-1);
    }
}
