using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class FinishEvnt : MonoBehaviourPun
{
    [SerializeField]
    private GameObject resultUi;
    [SerializeField]
    private GameObject winnerImg;
    [SerializeField]
    private Sprite[] playersImg;


    string winnerNickname;
    int numOfTheme;
    string nameOfTheme;

    private void Start()
    {


        resultUi.SetActive(false);
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winnerNickname = collision.gameObject.GetComponent<PhotonView>().Owner.NickName;
            IsFinished();
            Invoke("NextScene", 3f);

        }
    }

    public void IsFinished()
    {
        

        base.photonView.RPC("RPC_IsFunFinished", RpcTarget.All, winnerNickname);

        

    }



    void NextScene()
    {
        

        //yield return new WaitForSeconds(f);
        base.photonView.RPC("RPC_LoadNextScene", RpcTarget.All);


    }

    [PunRPC]
    private void RPC_IsFunFinished(string winnerNickname)
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            if (playerInfo.Value.NickName == winnerNickname)
            {
                //show Winner,
                resultUi.SetActive(true);
                winnerImg.GetComponent<Image>().sprite = playersImg[playerInfo.Value.ActorNumber - 1];
      

                


            }
        }
    }



    [PunRPC]
    public void RPC_LoadNextScene()
    {
        resultUi.SetActive(false);
        numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];

        switch ((numOfTheme + 1) % 3)
        {
            case 0:
                nameOfTheme = "Forest";
                break;
            case 1:
                nameOfTheme = "City";
                break;
            case 2:
                nameOfTheme = "Fox";
                break;
            case 3:
                nameOfTheme = "Medieval";
                break;
        }

        PhotonNetwork.LoadLevel($"Game Scenes/{nameOfTheme}");

      
    }


}
