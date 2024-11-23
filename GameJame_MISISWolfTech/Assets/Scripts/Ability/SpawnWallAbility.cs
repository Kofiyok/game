using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnWallAbility : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    void Start()
    {
        Instantiate(wallPrefab, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        MazeManager.mapArray[(int)transform.position.x, (int)transform.position.z] = -1;
        if ((int)transform.position.x - 1 >= 0 && (int)transform.position.x - 1 < 8 
            && (int)transform.position.z + 1 >= 2 && (int)transform.position.z + 1 < 7
            && MazeManager.mapArray[(int)transform.position.x - 1, (int)transform.position.z + 1] == 0)
        {
            MazeManager.mapArray[(int)transform.position.x - 1, (int)transform.position.z + 1] = -1;
            Instantiate(wallPrefab, new Vector3(transform.position.x - 1, 1, transform.position.z + 1), Quaternion.identity);
        }

        if ((int)transform.position.x + 1 >= 0 && (int)transform.position.x + 1 < 8
            && (int)transform.position.z + 1 >= 2 && (int)transform.position.z + 1 < 7
            && MazeManager.mapArray[(int)transform.position.x + 1, (int)transform.position.z + 1] == 0)
        {
            MazeManager.mapArray[(int)transform.position.x + 1, (int)transform.position.z + 1] = -1;
            Instantiate(wallPrefab, new Vector3(transform.position.x + 1, 1, transform.position.z + 1), Quaternion.identity);
        }

    }
}
