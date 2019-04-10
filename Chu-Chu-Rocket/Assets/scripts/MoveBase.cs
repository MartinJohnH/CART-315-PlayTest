using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    private Tiles tiles;

    void Awake()
    {
        // Setting up the reference.
        tiles = GameObject.Find("Tiles").GetComponent<Tiles>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        transform.position = tiles.GetRandomTilePosition();
        transform.position += new Vector3(0, 0.33f, 0);
        
    }
}
