using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttack : MonoBehaviour
{
    public EnemyData enemyData;
    private int Helf;
    private float cooldownTimer = 0.0f;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;  

        RaycastHit hit;
        if ((Physics.Raycast(transform.position, Vector3.forward, out hit, .5f)) && (IsCooldown()))
        {
            if (hit.collider.CompareTag("Hero"))
            {
                if (enemyData.typeEnemy == 0)
                    animator.SetBool("IsAttack", true);
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                Hero hero = Hero.GetComponent<Hero>();
                hero.health--;
                Debug.Log("Вроде наносит урон");
            }
            else if (hit.collider.CompareTag("ProtectWall"))
            {
                if (enemyData.typeEnemy == 0)
                    animator.SetBool("IsAttack", true);
                GameObject HeroColaider = hit.collider.gameObject;
                Hero hero = HeroColaider.GetComponent<Hero>();
                hero.health--;
            }
            else if (enemyData.typeEnemy == 0)
            {
                animator.SetBool("IsAttack", false);
            }
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
