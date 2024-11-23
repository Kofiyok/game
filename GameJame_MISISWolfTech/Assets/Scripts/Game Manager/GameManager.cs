using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] abilyties;
    private GameObject pendingObject;
    public GameObject rookButton, elephantButton, horseButton, abilityButton0, abilityButton1;
    private float timerForAbility0 = 0f, timerForAbility1 = 0f, timerForHeroRook = 0f, timerForHeroEleph = 0f, timerForHeroHorse = 0f;
    private bool abilityButton0Hidden = false, abilityButton1Hidden = false;
    public GameObject winScreen, loseScreen;
    public static bool heroRookLive = true, heroElephantLive = true, heroHorseLive = true;
    private RaycastHit hit;
    private Vector3 position;
    [SerializeField] private LayerMask layerMask;
    private bool isOnCell;
    public float gridSize;
    [SerializeField] private GameObject node;
    public GameObject researchCon;
    public static bool isPlacing = true;
    private HeroMovement heroMovement;
    private bool isAbility = false;
    private int abilityID, heroID;
    public static bool isDefeatLearn = false, isVictory = false;

    public void SetHero(int id)
    {
        heroID = id;
        pendingObject = null;
        pendingObject = Instantiate(objects[id], position, Quaternion.identity);
        foreach (Transform child in pendingObject.transform)
        {
            if (child.gameObject.tag == "Hero")
            {
                child.gameObject.tag = "Respawn";
            }
        }
        isAbility = false;
    }

    public void SetAbility(int id)
    {
        abilityID = id;
        pendingObject = null;
        pendingObject = Instantiate(abilyties[id], position, Quaternion.identity);
        isAbility = true;
    }

    public void SetHeroNull() 
    {
        pendingObject = null;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            position = hit.point;
            isOnCell = true;
        }
        else
        {
            isOnCell = false;
        }
    }
    void Update()
    {
        if (isDefeatLearn)
        {
            DefeatOnEasyMission();
        }

        if (isVictory)
        {
            VictoryOnMission();
        }
        ClickOnHero();
        if (pendingObject != null) 
        {
            isPlacing = true;
            pendingObject.transform.position = new Vector3(RoundToNearestGrid(position.x), RoundToNearestGrid(position.y), RoundToNearestGrid(position.z));
            if (Input.GetMouseButtonDown(0) && isOnCell && MazeManager.mapArray[(int)RoundToNearestGrid(position.x), (int)RoundToNearestGrid(position.z)] == 0)
            {
                foreach (Transform child in pendingObject.transform)
                {
                    if (child.gameObject.tag == "Respawn")
                    {
                        child.gameObject.tag = "Hero";
                    }
                }
                if (isAbility)
                {
                    if ((int)RoundToNearestGrid(position.z) > 1 && (int)RoundToNearestGrid(position.z) < 7 && abilityID == 0)
                    {
                        DisableButton();
                        Destroy(pendingObject);
                        PlaceObject();
                        isPlacing = false;
                        SetHeroNull();
                    }

                    if ((int)RoundToNearestGrid(position.z) == 4 && abilityID == 1)
                    {
                        DisableButton();
                        Destroy(pendingObject);
                        PlaceObject();
                        isPlacing = false;
                        SetHeroNull();
                    }
                }
                else
                {
                    DisableButton();
                    Destroy(pendingObject);
                    PlaceObject();
                    isPlacing = false;
                    SetHeroNull();
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(pendingObject);
            }
        }

        if (abilityButton0Hidden)
        {
            timerForAbility0 += Time.deltaTime;

            if (timerForAbility0 >= 200f)
            {
                abilityButton0.SetActive(true);
                timerForAbility0 = 0f;
                abilityButton0Hidden = false;
            }
        }

        if (abilityButton1Hidden)
        {
            timerForAbility1 += Time.deltaTime;

            if (timerForAbility1 >= 120f)
            {
                abilityButton1.SetActive(true);
                timerForAbility1 = 0f;
                abilityButton1Hidden = false;
            }
        }

        if (!heroRookLive)
        {
            timerForHeroRook += Time.deltaTime;

            if (timerForHeroRook >= 45f)
            {
                rookButton.SetActive(true);
                timerForHeroRook = 0f;
                heroRookLive = true;
            }
        }

        if (!heroElephantLive)
        {
            timerForHeroEleph += Time.deltaTime;

            if (timerForHeroEleph >= 50f)
            {
                elephantButton.SetActive(true);
                timerForHeroEleph = 0f;
                heroElephantLive = true;
            }
        }

        if (!heroHorseLive)
        {
            timerForHeroHorse += Time.deltaTime;

            if (timerForHeroHorse >= 25f)
            {
                elephantButton.SetActive(true);
                timerForHeroHorse = 0f;
                heroHorseLive = true;
            }
        }
    }

    public static void HeroDie(int diedId)
    {
        if (diedId == 0)
        {
            heroRookLive = false;
        } 
        else if (diedId == 1)
        {
            heroElephantLive = false;
        }
        else if (diedId == 2)
        {   
            heroHorseLive = false;
        }
    }

    private void DisableButton()
    {
        if (isAbility)
        {
            if (abilityID == 0)
            {
                abilityButton0.SetActive(false);
                abilityButton0Hidden = true;
            }
            else if (abilityID == 1)
            {
                abilityButton1.SetActive(false);
                abilityButton1Hidden = true;
            }
        }
        else
        {
            if (heroID == 0)
            {
                rookButton.SetActive(false);
                heroRookLive = true;
            }
            else if (heroID == 1)
            {
                elephantButton.SetActive(false);
                heroElephantLive = true;
            } 
            else if (heroID == 2)
            {
                horseButton.SetActive(false);
                heroHorseLive = true;
            }
        }
    }

    public void PlaceObject() 
    {
        GameObject Hero = Instantiate(pendingObject, position = new Vector3(RoundToNearestGrid(position.x), RoundToNearestGrid(position.y), RoundToNearestGrid(position.z)), Quaternion.identity);
        try
        {
            Hero.transform.GetChild(0).gameObject.SetActive(true);
            Hero.transform.GetChild(1).gameObject.SetActive(true);
            Hero.GetComponent<Hero>().enabled = true;
            Hero.GetComponent<HeroMovement>().enabled = true;
        }
        catch
        {
            try
            {
                Hero.GetComponent<SpawnWallAbility>().enabled = true;
            }
            catch
            {
                Hero.GetComponent<SpawnElectricGuard>().enabled = true;
            }
        }
        
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }

    private void ClickOnHero()
    {
        if (pendingObject == null && !isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.collider.gameObject.CompareTag("Hero")) 
                    {
                        if (heroMovement != null)
                        {
                            heroMovement.isPlayerSelected = false;
                            heroMovement = null;
                        }
                        node.GetComponent<Transform>().position = hit.collider.gameObject.transform.position;
                        heroMovement = hit.collider.transform.parent.gameObject.GetComponent<HeroMovement>();
                        heroMovement.isPlayerSelected = true;
                        node.SetActive(true);
                    }
                    else if (heroMovement != null && !heroMovement.isPlayerSelected)
                    {
                        node.SetActive(false);
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (heroMovement != null) 
                {
                    heroMovement.isPlayerSelected = false;
                    heroMovement = null;
                    node.SetActive(false);
                }
                
            }
        }

        if (heroMovement != null && !heroMovement.isPlayerSelected)
        {
            node.SetActive(false);
        }
    }

    private void Awake()
    {
        Debug.Log(ArmoryControl.choosenBattleIsts[0]);
        Debug.Log(ArmoryControl.choosenBattleIsts[1]);
        Debug.Log(ArmoryControl.choosenBattleIsts[2]);
        isDefeatLearn = false;
        isVictory = false;
        ActivePlayerButton();
    }

    private void ActivePlayerButton()
    {
        for (int i = 0; i < ArmoryControl.choosenAbilities.Count; i++)
        {
            if (ArmoryControl.choosenAbilities[i]!= null && ArmoryControl.choosenAbilities[i].id == 1)
            {
                abilityButton0.SetActive(true);
            }
            if (ArmoryControl.choosenAbilities[i] != null && ArmoryControl.choosenAbilities[i].id == 2)
            {
                abilityButton1.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("MissionId") <= 1) return;

        for (int i = 0; i < ArmoryControl.choosenBattleIsts.Count; i++)
        {
            if (ArmoryControl.choosenBattleIsts[i] == 0)
            {
                rookButton.SetActive(true);
            }
            if (ArmoryControl.choosenBattleIsts[i] == 1)
            {
                elephantButton.SetActive(true);
            }
            if (ArmoryControl.choosenBattleIsts[i] == 2)
            {
                horseButton.SetActive(true);
            }
        }
    }

    private void DefeatOnEasyMission()
    {
        TutorialControl.isLost = true;
        loseScreen.SetActive(true);
    }

    private void VictoryOnMission()
    {
        TutorialControl.isWon = true;
        if (PlayerPrefs.GetInt("MissionId") <= 1)
        {
            researchCon.GetComponent<ResearchControl>().IsAbilityDiscovered();
        }
        winScreen.SetActive(true);   
    }

    public void ButtonSceneChange()
    {
        SceneManager.LoadScene(1);
    }

    
}
