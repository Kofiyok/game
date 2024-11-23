using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HeroStats")]

public class HeroStats : ScriptableObject
{
    [Header("WaveInfo")]
    public int health;
    public float cooldownTimeFire;
    public float cooldownTimeMovement;
    public int damage;
    public float respawn;
    public int idBattleModule = -1;
    public int id;
}
