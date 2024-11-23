using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnMap : MonoBehaviour
{
    public GameObject grow;
    public GameObject row;
    public GameObject wall;
    public GameObject core;
    public MapData mapData;

    public void RenderMap(int[,] mapInt, GameObject Core)
    {
        Cell[,] map = new Cell[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Cell currentCell = new Cell(mapInt[i,j] );
                map[i, j] = currentCell;
            }
        }

        for (int i = 0; i < 8; i++) 
       {
         for (int j = 0; j < 8; j++) 
         {
            float x = 1 * i;
            float y = 0;
            float z = 1 * j;

            Vector3 currentCoordinate = new Vector3(x,y,z);

             if (map[i, j].GrowIndex == 0) { Instantiate(grow, currentCoordinate, Quaternion.identity, Core.transform); }
             else if (map[i, j].GrowIndex > 0) {Instantiate(wall, currentCoordinate, Quaternion.identity, Core.transform); }
             else {Instantiate(row, currentCoordinate, Quaternion.identity, Core.transform);}

         }
       } 
    }

    private void Awake()
    {
      RenderMap(mapData.map1,core);
    }

}
