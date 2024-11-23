using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionControl : MonoBehaviour
{
    private Mission[] archive = {
        new Mission("Mission1_1", 2, new string[3] {"Melee", "Flying", "Range"}, 5, 2, "SpeedUp", 1, "SlowDown", 1),
        new Mission("Mission1_2", 3, new string[2] {"Melee", "Range"}, 5, 1, "None", 1, "SlowDown", 1),
        new Mission("Mission2_1", 4, new string[3] {"Melee", "Range", "Flying"}, 4, 1, "None", 1, "SlowDown", 1),
        new Mission("Mission2_2", 4, new string[3] {"Melee", "Range", "Flying"}, 7, 3, "SpeedUp", 1, "SlowDown", 1)
        };
    public static MissionControl instance { get; private set;}
    public static PlotMission currentPlotMission = new PlotMission("BOSS", 10, new string[2] {"Melee", "Range"}, 3, 3, "None", 1, "None", 1, 2, 2);
    public List<Mission> missions = new List<Mission>() { new Mission("Mission1_1", 2, new string[3] {"Melee", "Flying", "Range"}, 5, 2, "SpeedUp", 1, "SlowDown", 1),
        new Mission("Mission1_2", 3, new string[2] {"Melee", "Range"}, 5, 1, "None", 1, "SlowDown", 1)};
    public Mission missionInProgress;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (MissionControl.instance.missions.Count == 0)
        {
            missions.Add(archive[2]);
            missions.Add(archive[3]);
        }
    }

    public void MissionCleared()
    {
        int currentId = PlayerPrefs.GetInt("MissionId");
        foreach(var c in missions)
        {
            if (c.id == currentId)
            {
                c.GetReward();
                missions.Remove(c);
                return;
            }
        }
    }

    public void MissionFailed()
    {
        int currentId = PlayerPrefs.GetInt("MissionId");
        foreach(var c in missions)
        {
            if (c.id == currentId)
            {
                c.GetPunish();
                missions.Remove(c);
                return;
            }
        }
    }

    public void MissionLaunch(int missionId)
    {
        PlayerPrefs.SetInt("MissionId", missionId);
        SceneManager.LoadScene(2);
    }
}
