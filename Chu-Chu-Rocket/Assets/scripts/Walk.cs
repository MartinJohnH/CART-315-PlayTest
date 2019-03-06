using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 0.2f;
    public static bool startWalk = false;
    private bool isWalkingFast = false;
    private int numEnteredRocket = 0;
    public string accelerateKey = "";

    private void Start()
    {
        startWalk = false;
        GameObject.Find("Walls").GetComponent<WallSpawner>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startWalk = true;
            GameObject.Find("Walls").GetComponent<WallSpawner>().enabled = true;
        }
        if (Input.GetKeyDown(accelerateKey))
        {
            isWalkingFast = !isWalkingFast;
            if (isWalkingFast)
            {
                speed *= 1.4f;
            }
            else
            {
                speed /= 1.4f;
            }
        }
    }

    void FixedUpdate()
    {
        if (startWalk)
        {
            transform.position += transform.right * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "wall1" || other.gameObject.tag == "wall2")
        {
            if(this.gameObject.tag == "mouse")
            {
                transform.Rotate(0.0f, -90.0f, 0.0f);
            }else if (this.gameObject.tag == "cat")
            {
                transform.Rotate(0.0f, 90.0f, 0.0f);
            }
        }
        if (other.gameObject.tag == "rocket")
        {
            numEnteredRocket++;
            Destroy(gameObject);
        }
    } 
}
