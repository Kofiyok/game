using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttak : MonoBehaviour
{
    public EnemyData enemyData;
    public GameObject projectile;
    private int Helf;
    private float cooldownTimer = 0f;
    private GameObject core;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        core = GameObject.Find("bollPull");
    }
    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (IsCooldown())
        {
            audioSource.Play();
            Instantiate(projectile, transform.position, projectile.transform.rotation, core.transform);
        }
    }
    private bool IsCooldown()
    {
        bool result;
        if (cooldownTimer < 0)
        {
            result = true;
            cooldownTimer = enemyData.attakCooldown;
        }
        else
        {
            result = false;
        }
        return result;
    }
}
