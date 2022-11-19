using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoad : MonoBehaviour
{
    //public Slider progressbar;
    //public TextMeshProUGUI loadtext;

    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private GameObject _background;
    [SerializeField]
    private GameObject _createUI;
    [SerializeField]
    private GameObject _currentRoomCanvas;


    private void Start()
    {
        _canvas.SetActive(false);
        _background.SetActive(false);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {

        /*
        AsyncOperation operation = SceneManager.LoadSceneAsync("Lobby");
        //operation.allowSceneActivation = false;

        //yield return new WaitForSeconds(2f);
        while (!operation.isDone)
        {

            
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime/3f);
            }
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime/3f);
            }
            if (progressbar.value >= 1f)
            {
                Debug.Log("Finish");
                yield return null;
                //operation.allowSceneActivation = true;
            }

            yield return null;
        }

        //operation.allowSceneActivation = true;
        */
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
        _canvas.SetActive(true);
        _background.SetActive(true);
        _createUI.SetActive(false);
        _currentRoomCanvas.SetActive(false);


    }
}
