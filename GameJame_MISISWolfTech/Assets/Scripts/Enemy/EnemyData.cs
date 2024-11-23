using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("EnemyInfo")]
    public int typeEnemy;
    public float HP;
    public float speed;
    public float attakCooldown;
    public GameObject enemyPrefab;
}

