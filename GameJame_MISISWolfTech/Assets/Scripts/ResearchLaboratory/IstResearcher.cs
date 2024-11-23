using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "IstResearcher")]
public class IstResearcher : ScriptableObject
{
    [Header("InfoIst")]
    public string Name;
    public bool isUnlocked = false;
    public int id;
}
