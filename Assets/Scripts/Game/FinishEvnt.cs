using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ExitGames.Client.Photon;
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


    private TextMeshProUGUI countTxt;

    string winnerNickname;
    int numOfTheme;
    string nameOfTheme;
    int GameCount;

    private const byte FinishtheGame = 0;

    private void Start()
    {

        countTxt = countDowntxt.GetComponent<TextMeshProUGUI>();
        resultUi.SetActive(false);
        numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];
        GameCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumOfPlay"];

    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    private void OnEvent(EventData obj)
    {
        if (obj.Code == FinishtheGame)
        {
            object data = (object)obj.CustomData;
            string WinnerNickName = (string)data;

            // change to the WinnerImg
            foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                if (playerInfo.Value.NickName == WinnerNickName)
                {

                    resultUi.SetActive(true);
                    winnerImg.GetComponent<Image>().sprite = playersImg[playerInfo.Value.ActorNumber - 1];

                }
            }

            //coutDown
            StartCoroutine(CountDown());
            StartCoroutine(LoadNextScene());

        }


        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winnerNickname = collision.gameObject.GetComponent<PhotonView>().Owner.NickName;
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(FinishtheGame, winnerNickname, raiseEventOptions, SendOptions.SendReliable);

            /*
            IsFinished();
            StartCoroutine(CountDown());
            Invoke("NextScene", 3f);
            */

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

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);
        resultUi.SetActive(false);

        switch ((numOfTheme + 1) % 2)
        {
            case 0:
                nameOfTheme = "Forest";
                break;
            case 1:
                nameOfTheme = "City";
                break;
        }


        int num = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumOfPlay"];
        Debug.Log($"Now GameCount: {num}");
        
        if (num == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {

                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.EmptyRoomTtl = 0;
                PhotonNetwork.CurrentRoom.PlayerTtl = 0;

                StartCoroutine(MasterLeaveRoom());
            }
            else
            {
                SceneManager.LoadScene($"Game Scenes/Main Menu");
                PhotonNetwork.Disconnect();
            }

        }
        else
        {
            SceneManager.LoadScene($"Game Scenes/{nameOfTheme}");
        }
         


    }

    public void IsFinished()
    {

        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("RPC_IsFunFinished", RpcTarget.All, winnerNickname);



    }

    [PunRPC]
    private void RPC_IsFunFinished(string winnerNickname)
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            if (playerInfo.Value.NickName == winnerNickname)
            {

                resultUi.SetActive(true);
                winnerImg.GetComponent<Image>().sprite = playersImg[playerInfo.Value.ActorNumber - 1];
               
                



            }
        }
    }


    public void NextScene()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("RPC_LoadNextScene", RpcTarget.All);


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
                break;
            case 1:
                nameOfTheme = "City";   
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

                StartCoroutine(MasterLeaveRoom());
            }
            else
            {
                PhotonNetwork.Disconnect();
            }
            
        }
        PhotonNetwork.LoadLevel($"Game Scenes/{nameOfTheme}");



    }

    IEnumerator MasterLeaveRoom()
    {
        yield return new WaitForSeconds(1.5f);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene($"Game Scenes/Main Menu");
    }    

    /*
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene($"Game Scenes/Main Menu");

        base.OnLeftRoom();
    }
    

    */

}
