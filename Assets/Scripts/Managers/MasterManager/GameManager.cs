using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject[] obj;
    public bool ischecked = false;

    public int GameCount;
    public GameObject gameUI;

    public void Start()
    {
        gameUI.SetActive(false);
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
        {
            Debug.Log($"Before GameCount: {GameCount}");
            GameCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumOfPlay"];
            GameCount += 1;
            ExitGames.Client.Photon.Hashtable options = new ExitGames.Client.Photon.Hashtable() { ["NumOfPlay"] = GameCount };
            PhotonNetwork.CurrentRoom.SetCustomProperties(options);
            Debug.Log($"After GameCount: {GameCount}");
        }
        
        StartCoroutine(Initiate());
    }

    IEnumerator Initiate()
    {

        yield return new WaitForSeconds(2f);
        PhotonNetwork.Instantiate(obj[PhotonNetwork.LocalPlayer.ActorNumber - 1].name, gameObject.GetComponent<Transform>().position, Quaternion.identity, 0);
        gameUI.SetActive(true);
    }



}
