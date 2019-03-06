using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;


public class Tiles : MonoBehaviour
{
    public GameObject prefab;
    public float gridX = 12f;
    public float gridY = 9f;
    public float posY = 0;
    public static float spacing = 1.1f;
    List<Vector3> tilePosition = new List<Vector3>();
    List<Vector3> tilePosition2 = new List<Vector3>();

    private int counter1 = 0;
    private int counter2 = 0;

    void Awake()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(x-5.5f, posY, (float)((y - 4.5) * -1)) * spacing;
                tilePosition.Add(pos);
                tilePosition2.Add(pos);
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
    }

    public Vector3 GetRandomTilePosition()
    {
        int randomTile = Random.Range(0, (int)(gridX * gridY));
        return tilePosition2[randomTile];
    }
    public Vector3 GetTilePosition(int tilePos)
    {
        return tilePosition2[tilePos];
    }


    public Vector3 GetRandomTilePosition1()
    {
        if (counter1 == (int)((int)(gridX * gridY) - gridX))
        {
            return new Vector3(0, -1, 0);
        }
        int randomTile = Random.Range((int)gridX, (int)(gridX * gridY));
        while (tilePosition[randomTile] == new Vector3(0, 0, 0))
        {
            randomTile = Random.Range((int)gridX, (int)(gridX * gridY));
        }
        Vector3 temp = tilePosition[randomTile];
        tilePosition[randomTile] = new Vector3(0,0,0);
        counter1++;
        return temp;
    }

    public Vector3 GetRandomTilePosition2()
    {
        if (counter2 == (int)((int)(gridX * gridY) - gridY))
        {
            return new Vector3(0, -1, 0);
        }
        int randomTile = Random.Range(0, ((int)(gridX * gridY)));
        while (randomTile % 12 == 0 || tilePosition[randomTile] == new Vector3(0, 0, 0))
        {
            randomTile = Random.Range(0, (int)(gridX * gridY));
        }
        Vector3 temp = tilePosition[randomTile];
        tilePosition[randomTile] = new Vector3(0, 0, 0);
        counter2++;
        return temp;
    }
}
