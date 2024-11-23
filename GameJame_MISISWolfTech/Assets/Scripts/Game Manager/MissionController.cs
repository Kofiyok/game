using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
    private int countWaveMis01 = 3, countWaveMis02 = 3, countWaveMis11 = 5,
        countWaveMis12 = 5, countWaveMis21 = 4, countWaveMis22 = 7, counter = -1;
    public WaveData[] currentWaves;
    private bool canSpawn = false;
    public static int cripsCount = 0;
    private float spawnInterval = 60f, timer = 0, timerWhenCripDie = 5f;
    private static int idMission;
    private int countMeeleCripA = 0, countRangeCripA = 0, countFlyRangeCripA = 0, countBossA = 0,
       countMeeleCripB = 0, countRangeCripB = 0, countFlyRangeCripB = 0, countBossB = 0,
       countMeeleCripC = 0, countRangeCripC = 0, countFlyRangeCripC = 0, countBossC = 0,
       countMeeleCripD = 0, countRangeCripD = 0, countFlyRangeCripD = 0, countBossD = 0,
       countMeeleCripE = 0, countRangeCripE = 0, countFlyRangeCripE = 0, countBossE = 0,
       countMeeleCripF = 0, countRangeCripF = 0, countFlyRangeCripF = 0, countBossF = 0,
       countMeeleCripG = 0, countRangeCripG = 0, countFlyRangeCripG = 0, countBossG = 0,
       countMeeleCripH = 0, countRangeCripH = 0, countFlyRangeCripH = 0, countBossH = 0;

    private void Awake()
    {
        idMission = PlayerPrefs.GetInt("MissionId");
        GameManager.isPlacing = false;
        canSpawn = false;
        if (PlayerPrefs.GetInt("MissionId") == 0)
        {
            counter = 0;
            currentWaves = new WaveData[countWaveMis01];
        } else if (PlayerPrefs.GetInt("MissionId") == 1)
        {
            counter += countWaveMis01;
            currentWaves = new WaveData[countWaveMis02];
        }
        else if (PlayerPrefs.GetInt("MissionId") == 2)
        {
            counter += countWaveMis01 + countWaveMis02;
            currentWaves = new WaveData[countWaveMis11];
        }
        else if (PlayerPrefs.GetInt("MissionId") == 3)
        {
            counter += countWaveMis01 + countWaveMis02 + countWaveMis11;
            currentWaves = new WaveData[countWaveMis12];
        }
        else if (PlayerPrefs.GetInt("MissionId") == 4)
        {
            counter += countWaveMis01 + countWaveMis02 + countWaveMis11 + countWaveMis12;
            currentWaves = new WaveData[countWaveMis21];
        }
        else if (PlayerPrefs.GetInt("MissionId") == 5)
        {
            counter += countWaveMis01 + countWaveMis02 + countWaveMis11 + countWaveMis12 + countWaveMis21;
            currentWaves = new WaveData[countWaveMis22];
        }

        for (int i = 0; i < currentWaves.Length; i++)
        {
            currentWaves[i] = waves[counter + i];
        }
        counter = 0;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (cripsCount > 0)
            {
                timer += Time.deltaTime;

                if (timer >= spawnInterval)
                {
                    SpawningWave();
                    timer = 0f;
                }
            }
            else
            {
                timer += Time.deltaTime;

                if (timer >= timerWhenCripDie)
                {
                    SpawningWave();
                    timer = 0f;
                }
            }
        }
    }

    private void SpawningWave()
    {   
        if (counter < currentWaves.Length)
        {
            cripsCount = currentWaves[counter].overAllCrip;

            countMeeleCripA = currentWaves[counter].countMeeleCripsA; countRangeCripA = currentWaves[counter].countRangeCripsA; countFlyRangeCripA = currentWaves[counter].countFlyRangeCripsA; countBossA = currentWaves[counter].countBOSSA;
            countMeeleCripB = currentWaves[counter].countMeeleCripsB; countRangeCripB = currentWaves[counter].countRangeCripsB; countFlyRangeCripB = currentWaves[counter].countFlyRangeCripsB; countBossB = currentWaves[counter].countBOSSB;
            countMeeleCripC = currentWaves[counter].countMeeleCripsC; countRangeCripC = currentWaves[counter].countRangeCripsC; countFlyRangeCripC = currentWaves[counter].countFlyRangeCripsC; countBossC = currentWaves[counter].countBOSSC;
            countMeeleCripD = currentWaves[counter].countMeeleCripsD; countRangeCripD = currentWaves[counter].countRangeCripsD; countFlyRangeCripD = currentWaves[counter].countFlyRangeCripsD; countBossD = currentWaves[counter].countBOSSD;
            countMeeleCripE = currentWaves[counter].countMeeleCripsE; countRangeCripE = currentWaves[counter].countRangeCripsE; countFlyRangeCripE = currentWaves[counter].countFlyRangeCripsE; countBossE = currentWaves[counter].countBOSSE;
            countMeeleCripF = currentWaves[counter].countMeeleCripsF; countRangeCripF = currentWaves[counter].countRangeCripsF; countFlyRangeCripF = currentWaves[counter].countFlyRangeCripsF; countBossF = currentWaves[counter].countBOSSF;
            countMeeleCripG = currentWaves[counter].countMeeleCripsG; countRangeCripG = currentWaves[counter].countRangeCripsG; countFlyRangeCripG = currentWaves[counter].countFlyRangeCripsG; countBossG = currentWaves[counter].countBOSSG;
            countMeeleCripH = currentWaves[counter].countMeeleCripsH; countRangeCripH = currentWaves[counter].countRangeCripsH; countFlyRangeCripH = currentWaves[counter].countFlyRangeCripsH; countBossH = currentWaves[counter].countBOSSH;

            while (countMeeleCripA > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateA[0], 1, currentWaves[counter].coordinateA[1]), prefabRotation);
                Debug.Log(currentWaves[counter].coordinateA[0] + currentWaves[counter].coordinateA[1]);
                countMeeleCripA--;
            }
            while (countMeeleCripB > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateB[0], 1, currentWaves[counter].coordinateB[1]), prefabRotation);
                countMeeleCripB--;
            }
            while (countMeeleCripC > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateC[0], 1, currentWaves[counter].coordinateC[1]), prefabRotation);
                countMeeleCripC--;
            }
            while (countMeeleCripD > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateD[0], 1, currentWaves[counter].coordinateD[1]), prefabRotation);
                countMeeleCripD--;
            }
            while (countMeeleCripE > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateE[0], 1, currentWaves[counter].coordinateE[1]), prefabRotation);
                countMeeleCripE--;
            }
            while (countMeeleCripF > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateF[0], 1, currentWaves[counter].coordinateF[1]), prefabRotation);
                countMeeleCripF--;
            }
            while (countMeeleCripG > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateG[0], 1, currentWaves[counter].coordinateG[1]), prefabRotation);
                countMeeleCripG--;
            }
            while (countMeeleCripH > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].meeleCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].meeleCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateH[0], 1, currentWaves[counter].coordinateH[1]), prefabRotation);
                countMeeleCripH--;
            }

            while (countRangeCripA > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateA[0], 1, currentWaves[counter].coordinateA[1]), prefabRotation);
                countRangeCripA--;
            }
            while (countRangeCripB > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateB[0], 1, currentWaves[counter].coordinateB[1]), prefabRotation);
                countRangeCripB--;
            }
            while (countRangeCripC > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateC[0], 1, currentWaves[counter].coordinateC[1]), prefabRotation);
                countRangeCripC--;
            }
            while (countRangeCripD > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateD[0], 1, currentWaves[counter].coordinateD[1]), prefabRotation);
                countRangeCripD--;
            }
            while (countRangeCripE > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateE[0], 1, currentWaves[counter].coordinateE[1]), prefabRotation);
                countRangeCripE--;
            }
            while (countRangeCripF > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateF[0], 1, currentWaves[counter].coordinateF[1]), prefabRotation);
                countRangeCripF--;
            }
            while (countRangeCripG > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateG[0], 1, currentWaves[counter].coordinateG[1]), prefabRotation);
                countRangeCripG--;
            }
            while (countRangeCripH > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].rangeCripData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].rangeCripData.enemyPrefab, new Vector3(currentWaves[counter].coordinateH[0], 1, currentWaves[counter].coordinateH[1]), prefabRotation);
                countRangeCripH--;
            }

            while (countFlyRangeCripA > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateA[0], 1, currentWaves[counter].coordinateA[1]), prefabRotation);
                countFlyRangeCripA--;
            }
            while (countFlyRangeCripB > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateB[0], 1, currentWaves[counter].coordinateB[1]), prefabRotation);
                countFlyRangeCripB--;
            }
            while (countFlyRangeCripC > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateC[0], 1, currentWaves[counter].coordinateC[1]), prefabRotation);
                countFlyRangeCripC--;
            }
            while (countFlyRangeCripD > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateD[0], 1, currentWaves[counter].coordinateD[1]), prefabRotation);
                countFlyRangeCripD--;
            }
            while (countFlyRangeCripE > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateE[0], 1, currentWaves[counter].coordinateE[1]), prefabRotation);
                countFlyRangeCripE--;
            }
            while (countFlyRangeCripF > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateF[0], 1, currentWaves[counter].coordinateF[1]), prefabRotation);
                countFlyRangeCripF--;
            }
            while (countFlyRangeCripG > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateG[0], 1, currentWaves[counter].coordinateG[1]), prefabRotation);
                countFlyRangeCripG--;
            }
            while (countFlyRangeCripH > 0)
            {
                Quaternion prefabRotation = currentWaves[counter].flyRangeData.enemyPrefab.transform.rotation;
                Instantiate(currentWaves[counter].flyRangeData.enemyPrefab, new Vector3(currentWaves[counter].coordinateH[0], 1, currentWaves[counter].coordinateH[1]), prefabRotation);
                countFlyRangeCripH--;
            }
            counter++;   
        }
        else
        {
            GameManager.isVictory = true;
        }
    }

    public void CanSpawnCrip()
    {
        canSpawn = true;
    }

    public static void Defeat()
    {
        GameManager.isDefeatLearn = true;
    }
}
