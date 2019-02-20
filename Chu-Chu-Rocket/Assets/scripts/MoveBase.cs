using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public Tiles tiles;

    void Awake()
    {
        // Setting up the reference.
        tiles = GameObject.Find("Tiles").GetComponent<Tiles>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        transform.position = tiles.GetRandomTilePosition();
    }
}
