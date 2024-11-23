using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChoosenBIButtons : MonoBehaviour
{
    
    public int buttonNum;
    public GameObject controller;
    private string path = "UI/ArmorySprites/";
    void Awake()
    {
        if (ArmoryControl.choosenBattleIsts[buttonNum] != -1)
        {
            this.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + controller.GetComponent<ArmoryControl>().BattleIstsGMS[ArmoryControl.choosenBattleIsts[buttonNum]].name);
        }
    }
}