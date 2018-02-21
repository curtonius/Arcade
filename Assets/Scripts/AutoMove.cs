using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    private VerticalMove verticalMove;
    private HorizontalMove horizontalMove;

    public bool random = false;
    private bool hit;
	// Use this for initialization
	void Start () {
        verticalMove = GetComponent<VerticalMove>();
        horizontalMove = GetComponent<HorizontalMove>();

        if (random)
            Random.InitState((int)Time.time);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!random) return;
        hit = true;
        float u1 = 1.0f - Random.value; //uniform(0,1] random doubles
        float u2 = 1.0f - Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
                     Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
        float randNormal = 0.5f * randStdNormal; //random normal(mean,stdDev^2)

        if (verticalMove)
            verticalMove.Move(randNormal);
        if (horizontalMove)
            horizontalMove.Move(randNormal);
    }

    // Update is called once per frame
    void Update ()
    {
        if (random && !hit) return;

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
