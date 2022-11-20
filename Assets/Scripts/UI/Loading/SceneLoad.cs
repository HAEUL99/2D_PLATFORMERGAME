using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    //public TextMeshProUGUI loadtext;

    /*
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private GameObject _background;
    [SerializeField]
    private GameObject _createUI;
    [SerializeField]
    private GameObject _currentRoomCanvas;
    */
    int numOfTheme;
    AsyncOperation operation;
    private void Start()
    {
        //_canvas.SetActive(false);
        // _background.SetActive(false);
        numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];
        StartCoroutine(LoadScene());
    }
    
    IEnumerator LoadScene()
    {


        if (numOfTheme == 0)
        {
            operation = SceneManager.LoadSceneAsync("City");
        }
        else
        {
            operation = SceneManager.LoadSceneAsync("Forest");
        }
        
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(0.3f);
        while (!operation.isDone)
        {

            
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime/5f);
            }
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime/5f);
            }
            if (progressbar.value >= 1f)
            {
                Debug.Log("Finish");
                yield return null;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        //operation.allowSceneActivation = true;
        
        //yield return new WaitForSeconds(2f);




    }
}
