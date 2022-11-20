using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class FinishEvnt : MonoBehaviourPun
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

    private void Start()
    {

        countTxt = countDowntxt.GetComponent<TextMeshProUGUI>();
        resultUi.SetActive(false);
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winnerNickname = collision.gameObject.GetComponent<PhotonView>().Owner.NickName;
            Debug.Log($"winnerNickname: {winnerNickname}");
            IsFinished();
            StartCoroutine(CountDown());
            //Invoke("NextScene", 3f);

        }
    }

    public void IsFinished()
    {
        

        base.photonView.RPC("RPC_IsFunFinished", RpcTarget.All, winnerNickname);

        

    }

    IEnumerator CountDown()
    {
        countTxt.text = "Move to next scene after 3 seconds";
        yield return new WaitForSeconds(1f);
        countTxt.text = "Move to next scene after 2 seconds";
        yield return new WaitForSeconds(1f);
        countTxt.text = "Move to next scene after 1 seconds";
        yield return new WaitForSeconds(2f);

        NextScene();
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
            /*
            case 2:
                nameOfTheme = "Fox";
                break;
            case 3:
                nameOfTheme = "Medieval";
                break;
            */
        }


        //PhotonNetwork.Destroy(GameManager.LocalPlayerInstance);

        PhotonNetwork.LoadLevel($"Game Scenes/{nameOfTheme}");

      
    }


}
