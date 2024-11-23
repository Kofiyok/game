using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDBar : MonoBehaviour
{
    [SerializeField] private HeroStats heroStats;
    public float cooldownTime; // Время кулдауна
    private float currentCooldown; // Прошедшее время для кулдауна

    private void Awake()
    {
        cooldownTime = heroStats.cooldownTimeMovement;
        currentCooldown = cooldownTime;
        transform.localScale = new Vector3(0.28f, 0.55f, 1);
    }

    private void Update()
    {
        Debug.Log("Привет");

        currentCooldown -= Time.deltaTime;
        transform.localScale = new Vector3(0.13f, currentCooldown / cooldownTime * 0.55f, 1);

        if (currentCooldown <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }


}
