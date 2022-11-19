using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Photon.Pun;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _nickNameInF;

    [SerializeField]
    private GameObject check_PopupObject;
    [SerializeField]
    private Check_Popup check_Popup;
    // Nickname to be marked
    public string _markednickName;
    [SerializeField]
    private GameObject warn_PopupObject;
    [SerializeField]
    private GameObject EnterName_txt;
    private string notice;

    public bool IsClicked;



    private void Start()
    {
        IsClicked = false;
        notice = "Are you sure using NickName: \r\n";
    }


    private void SetNickName()
    {
        // To prevent overlapping nickname
        int value = Random.Range(0, 9999);
        //PhotonNetwork.NickName = _nickNameInF.text + value.ToString();
        PlayerSetting.FullNickName = _nickNameInF.text + value.ToString();
        PlayerSetting.NickName = _nickNameInF.text;
        //_markednickName = _nickNameInF.text;
    }


    /*
    private void Update()
    {
        if (IsClicked == true)
        {
            IsClicked = !IsClicked;
            FindObjectOfType<AudioManager>().Play("clickbtn");
            
        }

    }
    */
    public void Click_Next()
    {
        //IsClicked = !IsClicked;
        FindObjectOfType<AudioManager>().Play("clickbtn");
        SetNickName();
        
        if (string.IsNullOrEmpty(PlayerSetting.NickName))
        {
            Debug.Log("PhotonNetwork.NickName is Empty");
            EnterName_txt.SetActive(false);
            warn_PopupObject.SetActive(true);
            
        }
        else
        {
            // show the check_popup
            check_Popup._noticetxt.text = notice + PlayerSetting.NickName;
            EnterName_txt.SetActive(false);
            check_PopupObject.SetActive(true);

            
        }
        
    }



}
