using UnityEngine;

public class SciptForBase : MonoBehaviour
{
    private int hpBase = 5;

    void Start()
    {
        hpBase = 5;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBaseHealth();
        CheckEnemyOnBase();
    }

    private void CheckBaseHealth()
    {
        if (hpBase <= 0)
        {
            MissionController.Defeat();
        }
    }

    private void CheckEnemyOnBase()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(0f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else if (Physics.Raycast(new Vector3(1f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else
        if (Physics.Raycast(new Vector3(2f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else
        if (Physics.Raycast(new Vector3(3f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else
        if (Physics.Raycast(new Vector3(4f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else
        if (Physics.Raycast(new Vector3(5f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else
        if (Physics.Raycast(new Vector3(6f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        } else
        if (Physics.Raycast(new Vector3(7f, 1f, 8f), Vector3.back, out hit, 1f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                EnemyMovement enemy = Hero.GetComponent<EnemyMovement>();
                enemy.health = 0;
                hpBase--;
            }
        }
        Debug.DrawRay(new Vector3(7f, 1f, 8f), Vector3.back, Color.blue);
    }


}
