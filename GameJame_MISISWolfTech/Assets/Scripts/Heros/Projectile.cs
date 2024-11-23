using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = -1f;
    [SerializeField] private HeroStats stats;
    private EnemyMovement lastestEnemy;
    private int count = 0;

    void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);

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

        if (stats.idBattleModule == 0)
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
            if ((Physics.Raycast(transform.position, Vector3.back, out hit, .1f)))
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
