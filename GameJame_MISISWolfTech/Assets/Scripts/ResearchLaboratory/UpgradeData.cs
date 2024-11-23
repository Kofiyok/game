using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UpgradeData")]
public class Upgrade : ScriptableObject
{
    [Header("InfoUpgrade")]
    public string Name;
    public bool isOpen = false; //открыт ли этот апгрейд
    public int researchProgress = 0; //сколько провели исследований
    public int researchNeeded; //сколько нужно провести исследований
    public bool isAbility;
    public bool isUnit;
    public bool isModule;
    public bool isDiscovering = false;
    public int id;
}