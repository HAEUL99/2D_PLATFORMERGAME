using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTheme : MonoBehaviour
{
    public int _numTheme;
    public GameObject[] ThemeImg = new GameObject[4];

    private void Start()
    {
        _numTheme = 100;
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }
    }

    public void OnClick_RabbitTheme()
    {
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }

        _numTheme = 0;
        ThemeImg[_numTheme].SetActive(true);

    }
    public void OnClick_FoxTheme()
    {
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }

        _numTheme = 2;
        ThemeImg[_numTheme].SetActive(true);
    }
    public void OnClick_CityTheme()
    {
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }

        _numTheme =1;
        ThemeImg[_numTheme].SetActive(true);
    }
    public void OnClick_MedievalTheme()
    {
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }

        _numTheme = 3;
        ThemeImg[_numTheme].SetActive(true);
    }
    
}
