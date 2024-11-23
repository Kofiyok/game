using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChoosenModulesButtons : MonoBehaviour
{
    public int buttonNum;
    private string path = "UI/LaboratorySprites/";
    void Awake()
    {
        if (ArmoryControl.choosenModules[buttonNum] != null)
        {
            this.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + ArmoryControl.choosenModules[buttonNum].name);
        }
    }
}