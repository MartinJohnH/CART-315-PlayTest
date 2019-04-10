using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public static float gridX = 12f;
    public static float gridY = 9f;
    public float posY = 0.35f;
    private readonly float spacing = Tiles.spacing;
    private int numOfSpawnedObj = 0;
    List<GameObject> spawnedObjects = new List<GameObject>();

    //https://gamedev.stackexchange.com/questions/106143/how-to-display-a-list-of-2d-arrays-in-the-inspector
    public ArrayLayout data;


    void Start()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                if(data.rows[y].row[x] != null && data.rows[y].row[x].Length != 0)
                {
                    Vector3 pos = new Vector3(x - 5.5f, posY, (float)((y - 4.5) * -1)) * spacing;
                    GameObject instantiatedObject = Instantiate(prefab, pos, Quaternion.identity);
                    spawnedObjects.Add(instantiatedObject);
                    if (data.rows[y].row[x].Equals("a"))
                    {
                        instantiatedObject.transform.eulerAngles = new Vector3(0, 180, 0);
                        numOfSpawnedObj++;
                    }
                    else if (data.rows[y].row[x].Equals("w"))
                    {
                        instantiatedObject.transform.eulerAngles = new Vector3(0, 270, 0);
                        numOfSpawnedObj++;
                    }
                    else if (data.rows[y].row[x].Equals("s"))
                    {
                        instantiatedObject.transform.eulerAngles = new Vector3(0, 90, 0);
                        numOfSpawnedObj++;
                    }
                    else if (data.rows[y].row[x].Equals("d"))
                    {
                        instantiatedObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        numOfSpawnedObj++;
                    }
                }
            }
        }
    }

    public int GetNumOfSpawnedObj()
    {
        return numOfSpawnedObj;
    }

    public List<GameObject> GetSpawnedObjects()
    {
        return spawnedObjects;
    }

}
