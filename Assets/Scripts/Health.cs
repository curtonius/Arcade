using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int hits;
    public bool died;

    public int points;
	public void TakeDamage()
    {
        if (gameObject.tag != "Player")
            GameManager.CurrentScore += points;
        --hits;
        if (hits <= 0)
        {
            died = true;
            if (gameObject.tag == "Player")
                GameManager.current.Die();
        }
    }
}
