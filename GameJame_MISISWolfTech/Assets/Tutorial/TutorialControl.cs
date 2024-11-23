using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    public static bool isLost = false;
    public static bool isWon = false;
    public static int eventId = 0;
    public static bool restartMission = false;
    public GameObject event0;
    public GameObject event1;
    public GameObject event2;
    public GameObject event3;

    public GameObject event0_1PressUpgrade;
    private bool event0_1done = false;
    public GameObject event0_2AbilityDescription;


    public GameObject event1_1pressAbilitySlot;
    private bool event1_1done = false;
    
    public GameObject event1_2pressAbility;
    private bool event1_2done = false;

    public GameObject event1_3pressIstSlot;
    private bool event1_3done = false;

    public GameObject event1_4pressIst;
    private bool event1_4done = false;

    public GameObject event1_5dialogue;
    //private bool event1_5done = false;

    

    ArmoryControl arm;
    public ResearchControl res;

    void Awake()
    {   
        if (isLost)
        {
            if (PlayerPrefs.GetInt("MissionId") <= 1)
            {
                SceneManager.LoadScene(2);
            }
            MissionControl.instance.MissionFailed();
        } 
        if (isWon)
        {
            if (PlayerPrefs.GetInt("MissionId") <= 1)
            {
                isWon = false;
                eventId++;
            }
        }
        ArmoryControl arm = GetComponent<ArmoryControl>();
        ResearchControl res = GetComponent<ResearchControl>();
        switch (eventId)
        {
            case 0:
                arm.BattleIsts_int[0] = 0;
                ArmoryControl.choosenBattleIsts[0] = 0;
                foreach (var c in res.upgrades)
                {
                    c.isDiscovering = false;
                    c.isOpen = false;
                }
                event0.SetActive(true);
                //res.istResearchers[0].isUnlocked = true;                
                //res.istResearchers[1].isUnlocked = false;                
                //Диалог 1
                //Нажмите на лабу
                //Текста про истов
                //Тык на Теслу
                //Тык на апгрейд
                //Диалог 2
                //Переход в обучающую миссию 1
            break;
            //------------------------------------------------------------------
            case 1:
                res.IsAbilityDiscovered();
                arm.BattleIsts_int[1] = 1;
                arm.BattleIsts_int[0] = 0;
                //this.GetComponent<ResearchControl>().istResearchers[1].isUnlocked = true;
                ArmoryControl.choosenBattleIsts[0] = 0;
                event1.SetActive(true);
                //Диалог 3
                //Нажмите на арсенал
                //Экипируйте абилку
                //Экипируйте слоняру
                //Диалог 4
                //I want to break free
            break;
            //------------------------------------------------------------------
            case 2:
                arm.BattleIsts_int[1] = 1;
                arm.BattleIsts_int[0] = 0;
                res.istResearchers[1].isUnlocked = true;
                event2.SetActive(true);

            break;
            //------------------------------------------------------------------
            case 3:
                event3.SetActive(true);
            break;
            case -1:
            break;
        }
    }

    void Update()
    {
        switch(eventId)
        {
            case 0:
                if (GetComponent<ResearchControl>().upgrades[1].isDiscovering && !event0_1done)
                {
                    event0_1PressUpgrade.SetActive(false);
                    event0_2AbilityDescription.SetActive(true);
                    event0_1done = true;
                }
            break;
            case 1:
                if (this.GetComponent<ArmoryControl>().type == 0 && !event1_1done)
                {
                    event1_1pressAbilitySlot.gameObject.SetActive(false);
                    event1_2pressAbility.gameObject.SetActive(true);
                    event1_1done = true;
                }

                if (ArmoryControl.choosenAbilities[0] != null && !event1_2done)
                {
                    event1_2pressAbility.gameObject.SetActive(false);
                    event1_3pressIstSlot.gameObject.SetActive(true);
                    event1_2done = true;
                }

                if (this.GetComponent<ArmoryControl>().num == 1 && !event1_3done)
                {
                    event1_3pressIstSlot.gameObject.SetActive(false);
                    event1_4pressIst.gameObject.SetActive(true);
                    event1_3done = true;
                }

                if (ArmoryControl.choosenBattleIsts[1] != -1 && !event1_4done)
                {
                    event1_4pressIst.SetActive(false);
                    event1_5dialogue.SetActive(true);
                    event1_4done = true;
                }
            break;
        }
    }
}