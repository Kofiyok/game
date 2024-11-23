using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmoryControl : MonoBehaviour
{
    public GameObject Controllers;

    public List<GameObject> BattleIstsGMS;
    public List<int> BattleIsts_int = new List<int>() { -1, -1, -1 };
    public List<Upgrade> Modules;
    public List<Upgrade> Abilities;

    [Space(5)]

    public List<Button> AbilityButtons;
    public List<Button> ModulesButtons;
    public List<Button> BattleIstButtons;
    public List<Button> ChooseButtons;

    [HideInInspector] public static List<int> choosenBattleIsts = new List<int>() { -1, -1, -1 };
    [HideInInspector] public static List<Upgrade> choosenAbilities = new List<Upgrade>() { null, null, null };
    [HideInInspector] public static List<Upgrade> choosenModules = new List<Upgrade>() { null, null, null };

    public GameObject description;
    public GameObject controller; 

    [HideInInspector] public int num = -1;
    public int type = -1;
    private string path = "UI/ArmorySprites/";

    public void Awake()
    {
        if (GetComponent<ResearchControl>().upgrades[4].isOpen) BattleIsts_int[2] = 2;
        if (TutorialControl.eventId == 0)
        {
            choosenBattleIsts[0] = 0;
        }
        foreach (Upgrade upgrade in GetComponent<ResearchControl>().upgrades) //better to state progress of researches in the end of the mission (beofre going to base)
        {
            if (upgrade.isOpen)
            {
                if (upgrade.isAbility )
                {
                    Abilities.Add(upgrade);
                }
                else if (upgrade.isModule)
                {
                    Modules.Add(upgrade);
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (choosenAbilities[i] != null)
            {
                AbilityButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + choosenAbilities[i].name);
            }
            else
            {
                AbilityButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (choosenModules[i] != null)
            {
                ModulesButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + choosenModules[i].name);
            }
            else
            {
                ModulesButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (choosenBattleIsts[i] != -1)
            {
                BattleIstButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + BattleIstButtons[choosenBattleIsts[i]].name);
            }
            else
            {
                BattleIstButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
            }
        }

        description.GetComponentInChildren<Text>().text = "";
    }

    public void GetAbilityButtons(int buttonIndex) 
    {
        if (choosenAbilities[buttonIndex] != null) 
            description.GetComponentInChildren<Text>().text = ability_description[choosenAbilities[buttonIndex].id];

        for(int i = 0; i < ChooseButtons.Count; i++)
        {
            ChooseButtons[i].gameObject.SetActive(false);
        }
        num = buttonIndex;
        type = 0;
        
        for (int i = 0; i < ChooseButtons.Count; i++)
        {
            if (i < Abilities.Count)
            {
                ChooseButtons[i].gameObject.SetActive(true);
                ChooseButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + Abilities[i].name); //name == Upgrade0, Name == Title

            }
            else
            {
                ChooseButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void GetBattleIstButtons(int buttonIndex)
    {
        if (choosenBattleIsts[buttonIndex] != -1) 
            description.GetComponentInChildren<Text>().text = battleIst_description[choosenBattleIsts[buttonIndex]];

        for(int i = 0; i < ChooseButtons.Count; i++)
        {
            ChooseButtons[i].gameObject.SetActive(false);
        }
        num = buttonIndex;
        type = 1;
        
        for (int i = 0; i < ChooseButtons.Count; i++)
        {
            if (i < BattleIsts_int.Count && BattleIsts_int[i] != -1)
            {
                ChooseButtons[i].gameObject.SetActive(true);
                ChooseButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + BattleIstsGMS[i].name);

            }
            else
            {
                ChooseButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void GetModuleButtons(int buttonIndex)
    {
        if (choosenModules[buttonIndex] != null) 
            description.GetComponentInChildren<Text>().text = modules_description[choosenModules[buttonIndex].id];

        for(int i = 0; i < ChooseButtons.Count; i++)
        {
            ChooseButtons[i].gameObject.SetActive(false);
        }
        if (choosenBattleIsts[buttonIndex] == -1) return;
        num = buttonIndex;
        type = 2;
        
        for (int i = 0; i < ChooseButtons.Count; i++)
        {
            if (i < Modules.Count)
            {
                ChooseButtons[i].gameObject.SetActive(true);
                ChooseButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + Modules[i].name); //name == Upgrade0, Name == Title

            }
            else
            {
                ChooseButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void ChooseEntity(int chooseNum) 
    {
        switch (type) //0 for ability change, 1 for BattleIsts change, 2 for modules change
        {
            case 0:
            /*
            for(int i = 0; i < ChooseButtons.Count; i++)
            {
                ChooseButtons[i].gameObject.SetActive(false);
            }
            */
            for (int i = 0; i < choosenAbilities.Count; i++)
            {
                if (choosenAbilities[i] == Abilities[chooseNum])
                {
                    choosenAbilities[i] = null;
                    AbilityButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
                    break;
                }
            }
            choosenAbilities[num] = Abilities[chooseNum];
            AbilityButtons[num].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + Abilities[chooseNum].name); 
            description.GetComponentInChildren<Text>().text = ability_description[Abilities[chooseNum].id];
            break;
//=======================================================================================================================
            case 1:
            /*
            for(int i = 0; i < ChooseButtons.Count; i++)
            {
                ChooseButtons[i].gameObject.SetActive(false);
            }
            */
            for (int i = 0; i < choosenBattleIsts.Count; i++)
            {
                if (choosenBattleIsts[i] != -1 && BattleIstsGMS[choosenBattleIsts[i]] == BattleIstsGMS[chooseNum])
                {
                    choosenBattleIsts[i] = -1;
                    choosenModules[i] = null;
                    BattleIstButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
                    ModulesButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
                    break;
                }
            }
            choosenBattleIsts[num] = BattleIstsGMS[chooseNum].GetComponent<Hero>().id;
            BattleIstButtons[num].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + BattleIstsGMS[chooseNum].name); 
            description.GetComponentInChildren<Text>().text = battleIst_description[BattleIstsGMS[chooseNum].GetComponent<Hero>().id];
            break;
//=======================================================================================================================
            case 2:
            /*
            for(int i = 0; i < ChooseButtons.Count; i++)
            {
                ChooseButtons[i].gameObject.SetActive(false);
            }
            */
            for (int i = 0; i < choosenModules.Count; i++)
            {
                if (choosenModules[i] == Modules[chooseNum])
                {
                    choosenModules[i] = null;
                    ModulesButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "Neutral");
                    break;
                }
            }
            choosenModules[num] = Modules[chooseNum];
            ModulesButtons[num].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + Modules[chooseNum].name); 
            description.GetComponentInChildren<Text>().text = modules_description[Modules[chooseNum].id];
            break;
//=======================================================================================================================
            case -1:
            Debug.Log("type = -1");
            break;
        }
    }

    private Dictionary<int, string> ability_description = new Dictionary<int, string>
    {
        { 1, "Позволяет установить 3 препятствия, которые преграждают путь союзным и вражеским снарядам. Враги при столкновении с укрытием атакуют его пока не разрушат.\nКулдаун: 200 сек" },
        { 2, "Позволяет призвать гвардейца, который готов пожертвовать жизнью за защиту одной прямой линии на поле.\nКулдаун: 120 сек" },
    };
    private Dictionary<int, string> battleIst_description = new Dictionary<int, string>
    {
        { 0, "Юнит, который атакует снарядами по прямой линии. Передвигается по прямой линии в любом направлении на любое количество тайлов.\nХП: 3" },
        { 1, "Юнит, который атакует двумя мощными снарядами по диагоналям. Передвигается по диагоналям в любом направлении на любое кол-во тайлов.\nХП: 2" },
        { 2, "Юнит, который наносит всем врагам на соседних клетках. Передвигается на 2 тайла вперед и один тайл в сторону в любых направлениях.\nХП: 5"}
    };
    private Dictionary<int, string> modules_description = new Dictionary<int, string>
    {
        { 0, "Заменяет снаряды, которыми стреляет юнит, на прошивающие. Эти снаряды проходят сквозь атакованного врага и наносят урон еще одному за ним. Но эти снаряды наносят меньше урона." },
        { 3, "Позволяет юниту делать шаг на 1-2 клетки назад во время перемещения."}
    };

}
