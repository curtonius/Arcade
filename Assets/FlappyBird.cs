using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public TimeLeft timeLeft;
    public Rigidbody bird;
    public GameObject pipePrefab;
    public float jumpPower;

    public float timeBetweenSpawns = 5;
    private float currentTime;
    private float speedyBoost;
    // Use this for initialization
    void Start ()
    {
        float height = Random.Range(5, 17);
        GameObject pipe1 = Instantiate(pipePrefab, transform.position + new Vector3(0, height, 0), Quaternion.identity);
        pipe1.transform.Rotate(0, 180, 0);
        GameObject pipe2 = Instantiate(pipePrefab, transform.position + new Vector3(0, height - 27, 0), Quaternion.identity);
        pipe2.transform.Rotate(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Jump") == 1)
        {
            bird.velocity = new Vector3(0, jumpPower, 0);
        }

        currentTime += Time.deltaTime;
        if(currentTime > timeBetweenSpawns)
        {
            speedyBoost += 0.5f;
            currentTime = 0;
            float height = Random.Range(9, 15);
            float close = Random.Range(4, 7)+20;
            GameObject pipe1 = Instantiate(pipePrefab, transform.position + new Vector3(0, height, 0), Quaternion.identity);
            pipe1.transform.Rotate(0, 180, 0);
            GameObject pipe2 = Instantiate(pipePrefab, transform.position + new Vector3(0, height- close, 0), Quaternion.identity);
            pipe2.transform.Rotate(0, 0, 180);

            pipe1.GetComponent<HorizontalMove>().movementSpeed += speedyBoost;
            pipe2.GetComponent<HorizontalMove>().movementSpeed += speedyBoost;
        }
    }
}
