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


    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumOfPlay"];
            GameCount += 1;
            ExitGames.Client.Photon.Hashtable options = new ExitGames.Client.Photon.Hashtable() { ["NumOfPlay"] = GameCount };
            PhotonNetwork.CurrentRoom.SetCustomProperties(options);
        }
        
        StartCoroutine(Initiate());
    }

    IEnumerator Initiate()
    {

        yield return new WaitForSeconds(2f);
        Debug.Log("?");
        PhotonNetwork.Instantiate(obj[PhotonNetwork.LocalPlayer.ActorNumber - 1].name, gameObject.GetComponent<Transform>().position, Quaternion.identity, 0);
        Debug.Log("??");
    }



}
