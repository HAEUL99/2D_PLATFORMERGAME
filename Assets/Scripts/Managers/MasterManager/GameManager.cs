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
   // public static GameObject PlayerInstance;
    public bool Ischecked = false;
    
    private void OnEnable()
    {
        PhotonNetwork.Instantiate(obj[PhotonNetwork.LocalPlayer.ActorNumber - 1].name, gameObject.GetComponent<Transform>().position, Quaternion.identity, 0);

    }
    /*
    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    

    private void Awake()
    {
        
    }

   
    public void IsConnedted()
    {
        PhotonNetwork.Instantiate(obj[PhotonNetwork.LocalPlayer.ActorNumber - 1].name, gameObject.GetComponent<Transform>().position, Quaternion.identity, 0);
    }
    */





}
