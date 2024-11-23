using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResearchControl : MonoBehaviour
{
    [SerializeField] public Upgrade[] upgrades;
    [SerializeField] private GameObject[] researchPanels;
    [SerializeField] public IstResearcher[] istResearchers;
    [SerializeField] public List<Button> istButtons;
    [SerializeField] private GameObject description1;
    [SerializeField] private GameObject description2;
    private Button[] arrayAllButton = new Button[10];
    private string path = "UI/LaboratorySprites/";

    private void Awake()
    {
        for (int i = 0; i < istButtons.Count; i++)
        {
            if (istResearchers[i].isUnlocked)
            {
                istButtons[i].gameObject.SetActive(true);
                istButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + istResearchers[i].name + "Icon");
            }
            else
            {
                istButtons[i].gameObject.SetActive(false);
            }
        }

        MakeButtonWorkable();
    }

    private void MakeButtonWorkable()
    {
        int upgradeCounter = 0;
        for (int i = 0; i < researchPanels.Length; i++) 
        {
            Button[] buttonsPanel = researchPanels[i].GetComponentsInChildren<Button>();
            int buttonCounter = 1;
            string standartButtonName = "Upgrade";
            foreach (Button button in buttonsPanel)
            {
                arrayAllButton[buttonCounter - 1] = button;
                if (button.name == standartButtonName + buttonCounter.ToString())
                {
                    button.GetComponentInChildren<Text>().text = upgrades[upgradeCounter].Name + " " + upgrades[upgradeCounter].researchProgress + "/" + upgrades[upgradeCounter].researchNeeded;
                    upgradeCounter++;
                }
                buttonCounter++;
                
            }
        }
    }

    public void StartDiscovery(int id)
    {
        foreach(var upgrade in upgrades) 
        {
            upgrade.isDiscovering = false;  
        }
        if (!upgrades[id].isOpen)
        {
            upgrades[id].isDiscovering = true;
        }


        if (id <= 2)
        {
            description1.GetComponentInChildren<Text>().text = upgrade_discription[id];
        }
        else
        {
            description2.GetComponentInChildren<Text>().text = upgrade_discription[id];
        }
    }

    public void IsAbilityDiscovered()
    {
        foreach (var upgrade in upgrades)
        {
            if (upgrade.isDiscovering)
            {
                upgrade.researchProgress++;
                if (upgrade.researchProgress >= upgrade.researchNeeded)
                {
                    upgrade.isOpen = true;
                    upgrade.isDiscovering = false;
                }
            }
        }
    }

    private Dictionary<int, string> upgrade_discription = new Dictionary<int, string>()
    {
        { 0, "Заменяет снаряды, которыми стреляет юнит, на прошивающие. Эти снаряды проходят сквозь атакованного врага и наносят урон еще одному за ним. Но эти снаряды наносят меньше урона." },
        { 1, "Позволяет установить 3 препятствия, которые преграждают путь союзным и вражеским снарядам. Враги при столкновении с укрытием атакуют его пока не разрушат.\nКулдаун: 200 сек" },
        { 2, "Позволяет призвать гвардейца, который готов пожертвовать жизнью за защиту одной прямой линии на поле.\nКулдаун: 120 сек" },
        { 3, "Позволяет юниту делать шаг на 1-2 клетки назад во время перемещения." },
        { 4, "Юнит, который наносит всем врагам на соседних клетках. Передвигается на 2 тайла вперед и один тайл в сторону в любых направлениях.\nХП: 5" }
    };
}