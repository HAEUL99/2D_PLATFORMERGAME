using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public GameObject[] Img;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Img[i].SetActive(false);
        }
        StartCoroutine("ShowImg");
    }

    IEnumerator ShowImg()
    {
        Img[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Img[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Img[2].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Img[3].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 4; i++)
        {
            Img[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);



    }

}
