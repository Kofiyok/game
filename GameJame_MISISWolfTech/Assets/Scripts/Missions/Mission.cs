using UnityEngine;

public class Mission
{
    public string name;
    public int id;
    public string[] enemyList;
    public int waves;
    public int difficulty;
    public string rewardType;
    public int rewardCoeff;
    public string punishType;
    public int punishCoeff;
    
    public Mission(string name, int id, string[] enemyList, int waves, int difficulty, string rewardType, int rewardCoeff, string punishType, int punishCoeff)
    {
        this.name = name;
        this.id = id;
        this.enemyList = enemyList;
        this.waves = waves;
        this.difficulty = difficulty;
        this.rewardType = rewardType;
        this.rewardCoeff = rewardCoeff;
        this.punishType = punishType;
        this.punishCoeff = punishCoeff;

    }

    
    public void GetReward()
    {
        switch (rewardType)
        {
            case "SpeedUp":
                for (int i = 0; i <= rewardCoeff; i++)
                {
                    MissionControl.instance.GetComponent<ResearchControl>().IsAbilityDiscovered();
                }
                break;
        }
    }   

    public void GetPunish()
    {
        switch (punishType)
        {
            case "SlowDown":
            break;
        }
    }
}
