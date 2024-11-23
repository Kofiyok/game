using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SectionButton : MonoBehaviour
{
    public int targetSceneId;
    
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneId != targetSceneId)
        SceneManager.LoadScene(targetSceneId);
    }
}
