using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotMission : Mission
{
    public int missionsLimit;
    public int missionsRequired;

    public PlotMission(string name, int id, string[] enemyList, int waves, int difficulty, string rewardType, int rewardCoeff, string punishType, int punishCoeff, int missionsLimit, int missionsRequired) : base(name, id, enemyList, waves, difficulty, rewardType, rewardCoeff, punishType, punishCoeff)
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
        this.missionsLimit = missionsLimit;
        this.missionsRequired = missionsRequired;
    }
}
