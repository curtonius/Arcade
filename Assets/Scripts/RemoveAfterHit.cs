using UnityEngine;
using System.Collections;

public class RemoveAfterHit : MonoBehaviour {

	public GameObject sender;
	public bool trigger;
	public bool collision;

    public bool doDamage;

    private void Start()
    {
        if (sender == null)
            sender = gameObject;
    }
    void OnCollisionEnter(Collision col)
	{
		if(!collision) return;
		if(col.gameObject == sender || col.transform.IsChildOf(sender.transform) || sender.transform.IsChildOf(col.gameObject.transform)) return;
		
        if(doDamage)
        {
            Health health = col.gameObject.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage();
                if(health.died)
                {
                    Destroy(col.gameObject);
                }
            }
        }

		Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(!trigger) return;
		if(sender != null && col.gameObject == sender || col.transform.IsChildOf(sender.transform) || sender.transform.IsChildOf(col.gameObject.transform)) return;

        if (doDamage)
        {
            Health health = col.gameObject.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage();
                if (health.died)
                {
                    Destroy(col.gameObject);
                }
            }
        }
       
        Destroy(gameObject);
	}
}
