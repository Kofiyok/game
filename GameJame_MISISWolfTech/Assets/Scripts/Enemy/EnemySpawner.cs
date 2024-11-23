using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private WaveData[] waveData;
    [SerializeField] private BoxCollider spawnArea;
    private int waveCounter = 0;

    /*void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        /*int countMeeleCrip = waveData[waveCounter].countMeeleCrips, countRangeCrip = waveData[waveCounter].countRangeCrips, countFlyingCrip = waveData[waveCounter].countFlyRangeCrips;
        GameObject[] crips = new GameObject[3];
        crips[0] = waveData[waveCounter].meeleCripData.enemyPrefab;
        crips[1] = waveData[waveCounter].rangeCripData.enemyPrefab;
        crips[2] = waveData[waveCounter].flyRangeData.enemyPrefab;

        int randomIndex = Random.Range(0, 3);

        while (countMeeleCrip > 0 || countRangeCrip > 0 || countFlyingCrip > 0)
        {
            randomIndex = Random.Range(0, 3);
            while ((crips[randomIndex] == waveData[waveCounter].meeleCripData.enemyPrefab && countMeeleCrip == 0) ||
            (crips[randomIndex] == waveData[waveCounter].rangeCripData.enemyPrefab && countRangeCrip == 0) ||
            (crips[randomIndex] == waveData[waveCounter].flyRangeData.enemyPrefab && countFlyingCrip == 0))
            {
                randomIndex = Random.Range(0, 3);
            }
            Debug.Log(randomIndex);


            Vector3 spawnPoint = new Vector3(
            Mathf.RoundToInt(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x)),
            Mathf.RoundToInt(Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)),
            Mathf.RoundToInt(Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)));
            Debug.Log(MazeManager.mapArray[(int)spawnPoint.x, (int)spawnPoint.z]);
            while (MazeManager.mapArray[(int)spawnPoint.x, (int)spawnPoint.z] != 0)
            {
                spawnPoint = new Vector3(
                Mathf.RoundToInt(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x)),
                Mathf.RoundToInt(Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)),
                Mathf.RoundToInt(Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)));
            }

            Quaternion prefabRotation = crips[randomIndex].transform.rotation;
            Instantiate(crips[randomIndex], spawnPoint, prefabRotation);

            if (crips[randomIndex] == waveData[waveCounter].meeleCripData.enemyPrefab)
            {
                countMeeleCrip--;
            }
            else if (crips[randomIndex] == waveData[waveCounter].rangeCripData.enemyPrefab)
            {
                countRangeCrip--;
            }
            else if (crips[randomIndex] == waveData[waveCounter].flyRangeData.enemyPrefab)
            {
                countFlyingCrip--;
            }

            yield return new WaitForSeconds(waveData[waveCounter].spawnDelay);
        }
        waveCounter++;
        
    }*/

}
