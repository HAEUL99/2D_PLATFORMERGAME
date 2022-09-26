using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Popup : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _noticetxt;

    public void OnClick_Yes()
    {
        //PhotonNetwork.GameVersion = "0.0.0";
        SceneManager.LoadScene("Main Menu");
    }

    public void OnClcik_No()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Close()
    {
        gameObject.SetActive(false);
    }
}
