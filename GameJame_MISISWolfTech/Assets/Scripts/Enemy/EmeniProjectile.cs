using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EmeniProjectile : MonoBehaviour
{
    private int cuttingAbility = 1;
    private float speed = 1f;

    void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);

        if (transform.position.z < -2)
        {
            Destroy(transform.gameObject);
        }
        try
        {
            if (MazeManager.mapArray[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)] == 1)
            {
                Destroy(gameObject);
            }
        }
        catch 
        {
            
        }

        RaycastHit hit;
        if ((Physics.Raycast(transform.position, Vector3.forward, out hit, .1f)))
        {
            if (hit.collider.CompareTag("Hero"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                GameObject Hero = HeroColaider.transform.parent.gameObject;
                Hero hero = Hero.GetComponent<Hero>();
                hero.health--;
                Destroy(gameObject);
            }
            else if (hit.collider.CompareTag("ProtectWall"))
            {
                GameObject HeroColaider = hit.collider.gameObject;
                Hero hero = HeroColaider.GetComponent<Hero>();
                hero.health--;
                Destroy(gameObject);
            }
        }
    }
}
