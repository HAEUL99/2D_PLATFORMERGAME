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

    
    

    // Start is called before the first frame update
    void Start()
    {
        startImg = gameObject.GetComponent<Image>();

        int numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];
        //Debug.Log($"chooseTheme._numTheme: {chooseTheme._numTheme}");
        startImg.sprite = change_img[numOfTheme];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
