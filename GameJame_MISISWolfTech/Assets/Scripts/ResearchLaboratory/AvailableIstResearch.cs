using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableIstResearch : MonoBehaviour
{
    public IstResearcher istResearcher;
    void Awake()
    {
        if (!istResearcher.isUnlocked)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
