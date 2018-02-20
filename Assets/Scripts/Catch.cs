using UnityEngine;
using System.Collections;

public class Catch : MonoBehaviour
{

    public GameObject sender;
    public bool trigger;
    public bool collision;

    public bool givePointsOnCatch = false;
    public int pointsToGive;

    void OnCollisionEnter(Collision col)
    {
        if (!collision) return;
        if (col.gameObject == sender || col.transform.IsChildOf(sender.transform)) return;

        Health health = col.gameObject.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage();
            if (health.died)
            {
                Destroy(col.gameObject);
            }
        }

        if (givePointsOnCatch)
            GameManager.CurrentScore += pointsToGive;
    }

    void OnTriggerEnter(Collider col)
    {
        if (!collision) return;
        if (col.gameObject == sender || col.transform.IsChildOf(sender.transform)) return;

        Health health = col.gameObject.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage();
            if (health.died)
            {
                Destroy(col.gameObject);
            }
        }

        if (givePointsOnCatch)
            GameManager.CurrentScore += pointsToGive;
    }
}
