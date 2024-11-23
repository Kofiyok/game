using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChoosenAbilityButtons : MonoBehaviour
{
    public int buttonNum;
    private string path = "UI/LaboratorySprites/";
    void Awake()
    {
        if (ArmoryControl.choosenAbilities[buttonNum] != null)
        {
            this.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + ArmoryControl.choosenAbilities[buttonNum].name);
        }
    }
}
