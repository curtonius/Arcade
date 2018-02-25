using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerstackerManager : MonoBehaviour {

    public GameObject spawner;
    public List<GameObject> burgerItems = new List<GameObject>();
    public float timeBetweenSpawns;
    private float currentTime;
    private float lastY;
    private Transform lastObject;

    private void Start()
    {
        lastObject = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        Health health = obj.GetComponent<Health>();
        if(health && health.points != 0)
        {
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<Rigidbody>().velocity = new Vector3();
            health.TakeDamage();
            obj.transform.position = lastObject.position + (new Vector3(0, lastObject.lossyScale.y / 2, 0)) + (new Vector3(0, obj.transform.localScale.y / 2, 0));

            float difference = obj.transform.position.y- lastObject.position.y;
            lastObject = obj.transform;
            GetComponent<BoxCollider>().center += new Vector3(0, difference*2, 0);
            obj.transform.parent = transform;
            Destroy(obj.GetComponent<Collider>());
        }
    }

    private void Update()
    {
        if (currentTime < timeBetweenSpawns)
            currentTime += Time.deltaTime;
        else
        {
            GameObject item = Instantiate(burgerItems[Random.Range(0, burgerItems.Count)], spawner.transform.position,Quaternion.identity);
            item.transform.position = spawner.transform.position + new Vector3(Random.Range(-spawner.transform.localScale.x/2, spawner.transform.localScale.x/2), 0, 0);
            currentTime = 0;
        }
    }
}
