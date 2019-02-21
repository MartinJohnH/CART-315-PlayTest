using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public Tiles tiles;
    public GameObject tile;
    public GameObject wall1;
    public GameObject wall2;

    private Vector3 offsetZ;
    private Vector3 offsetX;


    // Start is called before the first frame update
    void Start()
    {
        offsetZ = new Vector3(0, 0, (tile.GetComponent<Renderer>().bounds.size.z / 2) + (wall1.GetComponent<Renderer>().bounds.size.z / 2));
        offsetX = new Vector3((tile.GetComponent<Renderer>().bounds.size.z / 2) + (wall1.GetComponent<Renderer>().bounds.size.z / 2), 0, 0);
        WallBehaviour.isWallSet = true;
        StartCoroutine(Delay(1));
    }

    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (WallBehaviour.isWallSet)
        {
            Instantiate(wall1, tiles.GetRandomTilePosition1() + offsetZ, wall1.transform.rotation);
            Instantiate(wall2, tiles.GetRandomTilePosition2() - offsetX, wall2.transform.rotation);
            StartCoroutine(Delay(Random.Range(2, 5)));
        }
        else
        {
            StartCoroutine(Delay(Random.Range(2, 5)));
        }

    }
}
