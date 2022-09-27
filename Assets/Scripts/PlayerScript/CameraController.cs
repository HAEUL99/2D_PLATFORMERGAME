using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraController : MonoBehaviourPun
{
    [SerializeField] public Transform Player;
    //public bool isFollowing;
    //public GameObject Player;

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
    }
    

}
