using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tiles : MonoBehaviour
{
    public GameObject prefab;
    public float gridX = 12f;
    public float gridY = 9f;
    public float posY = 0;
    public static float spacing = 1.1f;
    List<Vector3> tilePosition = new List<Vector3>();
    List<Vector3> tilePosition2 = new List<Vector3>();
    
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
        Vector3 temp;
        try{
            temp = tilePosition2[randomTile];
        }catch (System.ArgumentOutOfRangeException e)
        {
            return tilePosition2[50];
        }
        return tilePosition2[randomTile];
    }
    public Vector3 GetTilePosition(int tileNumber)
    {
        Vector3 temp;
        try
        {
            temp = tilePosition2[tileNumber];
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            return tilePosition2[50];
        }
        return tilePosition2[tileNumber];
    }
    public int GetTileNumber(Vector3 tilePos)
    {
        for (int i=0; i< tilePosition2.Count; ++i)
        {
            if (tilePosition2[i] == tilePos)
            {
                return i;
            }
        }
        return -1;
    }
}
