using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    [SerializeField] private GameObject[] map;

    private void Start()
    {
        Instantiate(map[PlayerPrefs.GetInt("MissionId")], Vector3.zero, map[0].transform.rotation);
        MazeManager.MakeArray();
    }
}
