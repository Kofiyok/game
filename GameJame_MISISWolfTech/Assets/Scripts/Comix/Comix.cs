using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comix : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite second;
    public Sprite third;
    private int caunt;
    public GameObject text_1;
    public GameObject text_2;
    public GameObject text_3;
    public GameObject text_4;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        caunt = 0;
    }

    public void nextPaige()
    {
        switch (caunt) 
        {
            case 0:
                text_1.SetActive(false);
                spriteRenderer.sprite = second;
                text_2.SetActive(true);
                caunt++;
                break;
                
            case 1:
                text_2.SetActive(false);
                text_3.SetActive(true);

                spriteRenderer.sprite = third;
                caunt++;
                break;

            case 2:
                text_3.SetActive(false);
                text_4.SetActive(true);
                spriteRenderer.sprite = null;
                caunt++;

                break;
            case 3:
                SceneManager.LoadScene("Base");
                break;
        }
    }
}
