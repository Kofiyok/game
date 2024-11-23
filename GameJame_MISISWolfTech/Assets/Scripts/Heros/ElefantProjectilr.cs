using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElefantProjectilr : MonoBehaviour
{
    private float speed = -1f;
    private float cosP4 = 0.707107f;
    [SerializeField] private ProjectileData projectileData;
    [SerializeField] private HeroStats stats;
    private bool isRight;
    private EnemyMovement lastestEnemy;
    private int count = 0;

    private void Awake()
    {
        isRight = projectileData.isRight;
    }
    void Update()
    {
        if (isRight)
        {
            transform.position += new Vector3(speed * (-1) * cosP4 * Time.deltaTime, 0, speed * Time.deltaTime * cosP4);
        }
        else 
        {
            transform.position += new Vector3(speed * cosP4 * Time.deltaTime, 0, speed * Time.deltaTime * cosP4);
        }
        if (transform.position.z < -2)
        {
            Destroy(transform.gameObject);
        }
        try
        {
            if (MazeManager.mapArray[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)] == 1 || MazeManager.mapArray[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)] == -1)
            {
                Destroy(gameObject);
            }
        }
        catch
        {

        }

        if (stats.idBattleModule == 1)
        {
            RaycastHit hit;
            if ((Physics.Raycast(transform.position, Vector3.back, out hit, .1f)))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (count == 0)
                    {
                        GameObject HeroColaider = hit.collider.gameObject;
                        GameObject Hero = HeroColaider.transform.parent.gameObject;
                        EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                        lastestEnemy = enemy;
                        enemy.health = enemy.health - (stats.damage - stats.damage * 0.3f);
                        count++;
                    }
                    else
                    {
                        GameObject HeroColaider = hit.collider.gameObject;
                        GameObject Hero = HeroColaider.transform.parent.gameObject;
                        EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                        if (lastestEnemy != enemy)
                        {
                            enemy.health = enemy.health - (stats.damage - stats.damage * 0.3f);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
        else
        {
            RaycastHit hit;
            if ((Physics.Raycast(transform.position, Vector3.back, out hit, .5f)))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    GameObject HeroColaider = hit.collider.gameObject;
                    GameObject Hero = HeroColaider.transform.parent.gameObject;
                    EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                    enemy.health -= stats.damage;
                    Destroy(gameObject);
                }
            }
        }
    }
}
