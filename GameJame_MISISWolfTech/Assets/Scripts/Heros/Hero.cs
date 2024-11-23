using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Hero : MonoBehaviour
{
    public int id;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileLeft;
    [SerializeField] private GameObject projectileRight;
    private float cooldownTimer = 0.0f;
    private bool isOnCooldown = false; 
    public HeroStats HeroStats;
    public int health;
    private float cooldownTime;
    private bool theHorse;
    private float cosP4;
    private GameObject core;
    private bool isElefant;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        core = GameObject.Find("bollPull");
        cosP4 = 0.707107f;
        health = HeroStats.health;
        HeroStats.idBattleModule = -1;
        cooldownTime = HeroStats.cooldownTimeFire;
        if (HeroStats.id == 2)
        {
            theHorse = true;
        }
        else
        {
            theHorse = false;
        }

        if (HeroStats.id == 1)
        {
            isElefant = true;
        }
        else
        {
            isElefant = false;
        }

        for (int i = 0; i < ArmoryControl.choosenBattleIsts.Count; i++)
        {
            if (ArmoryControl.choosenBattleIsts[i] != -1 && ArmoryControl.choosenBattleIsts[i] == HeroStats.id && ArmoryControl.choosenModules[i] != null)
            {
                HeroStats.idBattleModule = ArmoryControl.choosenModules[i].id;
            }
        }
    }

    void FixedUpdate()
    {
        if (HeroStats.id != 3)
        {
            Attack();
        }
    }

    private void Update()
    {
        CheckHealth();
    }

    public void StartCooldown()
    {
        if (!isOnCooldown)
        {
            isOnCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }
    private void CheckHealth()
    {
        if (health <= 0)
        { 
            if (HeroStats.id == 3)
            {
                MazeManager.mapArray[(int)transform.position.x, (int)transform.position.z] = 0;
            }
            GameManager.HeroDie(HeroStats.id);
            Destroy(gameObject);
        }
    }
    private void Attack()
    {
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime; // ��������� ������ ��������
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
            }
        }
        else if (!theHorse && HeroStats.id != 4)
        {
            if (!isElefant)
            {
                audioSource.Play();
                Instantiate(projectile, transform.position, projectile.transform.rotation, core.transform);
                StartCooldown();

            }
            else
            {
                audioSource.Play();
                Instantiate(projectileLeft, transform.position, projectile.transform.rotation, core.transform);
                Instantiate(projectileRight, transform.position, projectile.transform.rotation, core.transform);
                StartCooldown();

            }
        }
        else
        {
            ElectricGuardAttack();
            HorseAttacke();
            StartCooldown();
        }
    }

    private void ElectricGuardAttack()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.back, 2.5f);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyCollider = hit.collider.gameObject;
                GameObject Enemy = EnemyCollider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
    }

    private void HorseAttacke() 
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, new Vector3(-1 * cosP4, 0, -1 * cosP4), out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, new Vector3(1 * cosP4, 0, -1 * cosP4), out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, new Vector3(-1 * cosP4, 0, 1 * cosP4), out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }
        if (Physics.Raycast(transform.position, new Vector3(1 * cosP4, 0, 1 * cosP4), out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject EnemyColaider = hit.collider.gameObject;
                GameObject Enemy = EnemyColaider.transform.parent.gameObject;
                EnemyMovement enemy = Enemy.GetComponent<EnemyMovement>();
                enemy.health -= HeroStats.damage;
            }
        }

    }

}
