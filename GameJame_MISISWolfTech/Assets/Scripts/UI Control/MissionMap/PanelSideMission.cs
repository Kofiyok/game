using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelSideMission : MonoBehaviour
{
    public int PanelNumber;
    public TMP_Text MissionName;
    public GameObject MissionArt;
    public GameObject DifficultyArt;
    public List<GameObject> EnemyImages;
    public TMP_Text Waves;
    public TMP_Text RewardText;
    public TMP_Text PunishText;
    public Button StartButton;

    private string path = "UI/MissionMapSprites/";

    void Awake()
    {
        Mission mission = MissionControl.instance.missions[PanelNumber];
        MissionName.text = mission.name;
        MissionArt.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "MissionArt" + mission.name);
        if (mission.difficulty == 1)
        {
            DifficultyArt.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "FirstDifficulty");
        }
        else if (mission.difficulty == 2)
        {
            DifficultyArt.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "SecondDifficulty");
        }
        else if (mission.difficulty == 3)
        {
            DifficultyArt.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + "ThirdDifficulty");
        }
        for (int i = 0; i < 3; i++)
        {
            if (i < mission.enemyList.Length)    
            {    
                EnemyImages[i].SetActive(true);
                EnemyImages[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + mission.enemyList[i]);
            }
            else
            {
                EnemyImages[i].SetActive(false);
            }
        }
        Waves.text = "Волны: " + mission.waves.ToString();
        RewardText.text = mission.rewardType;
        PunishText.text = mission.punishType;
    }
}
