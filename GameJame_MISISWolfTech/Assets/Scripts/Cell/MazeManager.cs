using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public static int[,] mapArray = new int[8,8];
    public static GameObject map;

    private void Start()
    {

    }

    public static void MakeArray() 
    {
        map = GameObject.FindGameObjectWithTag("Map");
        CreateArray();
    }

    private static void CreateArray()
    {
        Transform parentTransform = map.transform;

        foreach (Transform child in parentTransform)
        {
            if (child.gameObject.tag == "Wall")
            {
                mapArray[(int)child.gameObject.transform.position.x, (int)child.gameObject.transform.position.z] = 1;
            }
            else if (child.gameObject.tag == "Water")
            {
                mapArray[(int)child.gameObject.transform.position.x, (int)child.gameObject.transform.position.z] = 2;
            }
            else
            {
                mapArray[(int)child.gameObject.transform.position.x, (int)child.gameObject.transform.position.z] = 0;
            }
        }
    }
}
