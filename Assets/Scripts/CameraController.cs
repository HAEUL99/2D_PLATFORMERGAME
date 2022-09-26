using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraController : MonoBehaviourPun
{
    //[SerializeField] public Transform player;
    public bool isFollowing;
    //public GameObject Player;
    
    private void Start()
    {
        if (photonView.IsMine)
        {
            gameObject.GetComponent<Camera>().enabled = true;
            gameObject.GetComponent<AudioListener>().enabled = true;
            //transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

        }
        else
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }
        //Player = FindObjectOfType<PlayerMovement>(
        /*
        if (photonView.IsMine)
        {
            //gameObject.GetComponentInChildren<Camera>().enabled = true;
            //gameObject.GetComponentInChildren<AudioListener>().enabled = true;
            Debug.Log("Mine");
        }

        else
        {
            gameObject.GetComponentInChildren<Camera>().enabled = false;
            gameObject.GetComponentInChildren<AudioListener>().enabled = false;
            Debug.Log("Mine!");
        }
        */
        //isFollowing = false;
    }
    

}
