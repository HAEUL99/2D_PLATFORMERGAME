using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class FinishEvnt : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject resultUi;
    [SerializeField]
    private GameObject countDowntxt;
    [SerializeField]
    private GameObject winnerImg;
    [SerializeField]
    private Sprite[] playersImg;

    //public GameObject[] obj;

    private TextMeshProUGUI countTxt;

    string winnerNickname;
    int numOfTheme;
    string nameOfTheme;
    int GameCount;
    private void Start()
    {

        countTxt = countDowntxt.GetComponent<TextMeshProUGUI>();
        resultUi.SetActive(false);
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            winnerNickname = collision.gameObject.GetComponent<PhotonView>().Owner.NickName;

            IsFinished();
            StartCoroutine(CountDown());
            Invoke("NextScene", 3f);

        }
    }


    

    IEnumerator CountDown()
    {
        countTxt.text = "Move to next scene after 3 seconds";
        yield return new WaitForSeconds(1f);
        countTxt.text = "Move to next scene after 2 seconds";
        yield return new WaitForSeconds(1f);
        countTxt.text = "Move to next scene after 1 seconds";
        yield return new WaitForSeconds(1f);
   
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

    public void IsFinished()
    {


        base.photonView.RPC("RPC_IsFunFinished", RpcTarget.All, winnerNickname);



    }



    [PunRPC]
    public void RPC_LoadNextScene()
    {

        
        
        
        resultUi.SetActive(false);
        numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];
        GameCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumOfPlay"];



        switch ((numOfTheme + 1) % 2)
        {
            case 0:
                nameOfTheme = "Forest";
                //nameOfTheme = "LoadingScenBunny";
                break;
            case 1:
                nameOfTheme = "City";
                //nameOfTheme = "LoadingScenCity";
                break;
        }



        Debug.Log($"Now GameCount: {GameCount}");
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["NumOfPlay"] == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.EmptyRoomTtl = 0;
                PhotonNetwork.CurrentRoom.PlayerTtl = 0;

                //foreach(Player player in PhotonNetwork.PlayerList)


                PhotonNetwork.Disconnect();
            }
            else
            {
                PhotonNetwork.Disconnect();
            }

        }
        else
        {
            PhotonNetwork.LoadLevel($"Game Scenes/{nameOfTheme}");
        }

        



    }

    public void NextScene()
    {

        base.photonView.RPC("RPC_LoadNextScene", RpcTarget.All);


    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel($"Game Scenes/Main Menu");

        base.OnLeftRoom();
    }
    



}
