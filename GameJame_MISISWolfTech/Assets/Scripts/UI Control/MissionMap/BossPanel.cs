using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossPanel : MonoBehaviour
{
    public Button ButtonMissionRemains;
    public GameObject MissionDeadline;
    public GameObject BossName;
    public GameObject BossImage;

    private string path = "UI/MissionMapSprites/";

    void Awake()
    {
        PlotMission plotMission = MissionControl.currentPlotMission;
        BossName.GetComponentInChildren<TMP_Text>().text = plotMission.name;
        MissionDeadline.GetComponentInChildren<TMP_Text>().text = plotMission.missionsLimit.ToString();
        BossImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(path + plotMission.name);
        if (plotMission.missionsRequired > 0)
        {
            ButtonMissionRemains.GetComponentInChildren<TMP_Text>().text = "Нужно пройти миссий: " + plotMission.missionsRequired.ToString();
            ButtonMissionRemains.enabled = false;
        }
        else
        {
            ButtonMissionRemains.enabled = true;
            ButtonMissionRemains.GetComponentInChildren<TMP_Text>().text = "Старт";
        }
    }
}
