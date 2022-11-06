using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTheme : MonoBehaviour
{
    public int _numTheme;
    public GameObject[] frame = new GameObject[2];

    private void Start()
    {
        _numTheme = 100;
        for (int i = 0; i < frame.Length; i++)
        {
            frame[i].SetActive(false);
        }
    }

    public void OnClick_RabbitTheme()
    {
        for (int i = 0; i < frame.Length; i++)
        {
            frame[i].SetActive(false);
        }

        _numTheme = 0;


        frame[_numTheme].SetActive(true);

    }
    /*
    public void OnClick_FoxTheme()
    {
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }

        _numTheme = 2;
        ThemeImg[_numTheme].SetActive(true);
    }
    */
    public void OnClick_CityTheme()
    {
        for (int i = 0; i < frame.Length; i++)
        {
            frame[i].SetActive(false);
        }

        _numTheme =1;
        frame[_numTheme].SetActive(true);
    }
    /*
    public void OnClick_MedievalTheme()
    {
        for (int i = 0; i < ThemeImg.Length; i++)
        {
            ThemeImg[i].SetActive(false);
        }

        _numTheme = 3;
        ThemeImg[_numTheme].SetActive(true);
    }
    */
    
}
