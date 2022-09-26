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
    private TextMeshProUGUI _nickNametxt;
    [SerializeField]
    private GameObject check_PopupObject;
    [SerializeField]
    private Check_Popup check_Popup;
    // Nickname to be marked
    public string _markednickName;
    [SerializeField]
    private GameObject warn_PopupObject;

    private string notice;


    private void Awake()
    {
       // PhotonNetwork.NickName = null;

    }

    private void Start()
    {
        notice = "Are you sure using NickName: ";
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

    private void ShowNickName()
    {
        _nickNametxt.text = _nickNameInF.text;

    }


    public void Click_OK()
    {
        ShowNickName();
        SetNickName();

    }

    public void Click_Next()
    {
        if (string.IsNullOrEmpty(PlayerSetting.NickName))
        {
            Debug.Log("PhotonNetwork.NickName is Empty");
            warn_PopupObject.SetActive(true);
        }
        else
        {
            // show the check_popup
            check_Popup._noticetxt.text = notice + PlayerSetting.NickName;
            check_PopupObject.SetActive(true);

            
        }
        
    }



}
