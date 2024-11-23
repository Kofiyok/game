using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public int buttonIndex;

    void Awake()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LaunchMission);
    }

    void LaunchMission()
    {
        PlayerPrefs.SetInt("MissionId", MissionControl.instance.missions[buttonIndex].id);
        SceneManager.LoadScene(2);
    }
}
