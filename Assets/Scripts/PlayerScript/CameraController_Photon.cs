using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController_Photon : MonoBehaviourPun
{
    public bool isFollowing;


    private void Start()
    {
        if (photonView.IsMine)
        {
            gameObject.GetComponent<Camera>().enabled = true;


        }
        else
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }

    }
}