using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ProjectileData")]

public class ProjectileData : ScriptableObject
{
    [Header("Projectile Info")]
    public int cuttingAbility = 1;
    public float speed = -1f;
    public bool isRight;
}
