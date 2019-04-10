using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public Tiles tiles;
    public GameObject tile;
    public GameObject wall1;
    public GameObject wall2;

    public List<GameObject> oldWalls1 = new List<GameObject>();
    public List<GameObject> oldWalls2 = new List<GameObject>();

    public int wallCounter = 0;

    private Vector3 offsetZ;
    private Vector3 offsetX;

    public int tileNumber1 = 57;
    public int tileNumber2 = 50;


    // Start is called before the first frame update
    void Start()
    {
        wallCounter = 0;
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
            //print(oldWalls2.Count);
            wallCounter++;
            if (wallCounter > 1)
            {
                if (tiles.GetTileNumber(oldWalls1[wallCounter - 2].transform.position - offsetZ) != -1)
                {
                    tileNumber1 = tiles.GetTileNumber(oldWalls1[wallCounter - 2].transform.position - offsetZ) + 1;
                }
                else
                {
                    tileNumber1++;
                }
                if (tiles.GetTileNumber(oldWalls2[oldWalls2.Count - 1].transform.position + offsetX) != -1)
                {
                    tileNumber2 = tiles.GetTileNumber(oldWalls2[oldWalls2.Count - 1].transform.position + offsetX) + 1;
                }
                else
                {
                    tileNumber2++;
                }
            }
            oldWalls1.Add(Instantiate(wall1, tiles.GetTilePosition(tileNumber1) + offsetZ, wall1.transform.rotation));
            oldWalls2.Add(Instantiate(wall2, tiles.GetTilePosition(tileNumber2) - offsetX, wall2.transform.rotation));
        }
        StartCoroutine(Delay(3));
    }

}
