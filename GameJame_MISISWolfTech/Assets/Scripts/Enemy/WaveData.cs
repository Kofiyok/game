using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveData")]
public class WaveData : ScriptableObject
{
    [Header("EnemyData")]
    public EnemyData BOSS;
    public EnemyData flyRangeData;
    public EnemyData rangeCripData;
    public EnemyData meeleCripData;
    public int overAllCrip;
    [Header("WaveInfo")]
    public float spawnDelay;
    public int[] coordinateA = new int[2] { 0, 0 };
    public int countMeeleCripsA;
    public int countRangeCripsA;
    public int countFlyRangeCripsA;
    public int countBOSSA;
    [Space(5)]
    public int[] coordinateB = new int[2] { 0, 1 };
    public int countMeeleCripsB;
    public int countRangeCripsB;
    public int countFlyRangeCripsB;
    public int countBOSSB;
    [Space(5)]
    public int[] coordinateC = new int[2] { 0, 2 };
    public int countMeeleCripsC;
    public int countRangeCripsC;
    public int countFlyRangeCripsC;
    public int countBOSSC;
    [Space(5)]
    public int[] coordinateD = new int[2] { 0, 3 };
    public int countMeeleCripsD;
    public int countRangeCripsD;
    public int countFlyRangeCripsD;
    public int countBOSSD;
    [Space(5)]
    public int[] coordinateE = new int[2] { 0, 4 };
    public int countMeeleCripsE;
    public int countRangeCripsE;
    public int countFlyRangeCripsE;
    public int countBOSSE;
    [Space(5)]
    public int[] coordinateF = new int[2] { 0, 5 };
    public int countMeeleCripsF;
    public int countRangeCripsF;
    public int countFlyRangeCripsF;
    public int countBOSSF;
    [Space(5)]
    public int[] coordinateG = new int[2] { 0, 6 };
    public int countMeeleCripsG;
    public int countRangeCripsG;
    public int countFlyRangeCripsG;
    public int countBOSSG;
    [Space(5)]
    public int[] coordinateH = new int[2] { 0, 7 };
    public int countMeeleCripsH;
    public int countRangeCripsH;
    public int countFlyRangeCripsH;
    public int countBOSSH;
}
