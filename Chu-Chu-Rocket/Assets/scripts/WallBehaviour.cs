using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    public string moveUp = "";
    public string moveDown = "";
    public string moveLeft = "";
    public string moveRight = "";

    public GameObject tile;
    public float spacing = 0.01f;

    public Material MaterialGhost;
    public Material MaterialSet;

    public static bool isWallSet = false;
    private bool isWallSet2 = false;
    private int durability;

    public Material[] wallMaterials;


    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().material = MaterialGhost;
        isWallSet = false;
        isWallSet2 = false;
        durability = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWallSet2 && Input.GetButtonDown(moveUp) && transform.position.z <= 3.9f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + tile.GetComponent<Renderer>().bounds.size.z + spacing);
        }
        if (!isWallSet2 && Input.GetButtonDown(moveDown) && transform.position.z >= -2.8f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - tile.GetComponent<Renderer>().bounds.size.z - spacing);
        }
        if (!isWallSet2 && Input.GetButtonDown(moveLeft) && transform.position.x >= -5.5f)
        {
            transform.position = new Vector3(transform.position.x - tile.GetComponent<Renderer>().bounds.size.z - spacing, transform.position.y, transform.position.z);
        }
        if (!isWallSet2 && Input.GetButtonDown(moveRight) && transform.position.x <= 5.5f)
        {
            transform.position = new Vector3(transform.position.x + tile.GetComponent<Renderer>().bounds.size.z + spacing, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWallSet = true;
            isWallSet2 = true;
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<MeshRenderer>().material = wallMaterials[durability];
        }
        if (durability >= 14)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mouse" || other.gameObject.tag == "cat")
        {
            ReduceDurability();
        }
    }

    public void ReduceDurability()
    {
        durability++;
        if (durability < 14)
        {
            this.GetComponent<MeshRenderer>().material = wallMaterials[durability];
        }
    }


}
