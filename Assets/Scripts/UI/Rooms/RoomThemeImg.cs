using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoomThemeImg : MonoBehaviour
{
    [SerializeField]
    private ChooseTheme chooseTheme;
    [SerializeField]
    private Sprite[] change_img = new Sprite[2];
    private Image startImg;

    
    

    void Start()
    {
        startImg = gameObject.GetComponent<Image>();

        int numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];
        startImg.sprite = change_img[numOfTheme];
    }


}
