using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonSideMission : MonoBehaviour
{
    public int buttonNumber;

    public void Awake()
    {
        Mission mission;
        try
        {
            mission = MissionControl.instance.missions[buttonNumber];
        }
        catch
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.GetComponentInChildren<TMP_Text>().text = mission.name;
    }
}
