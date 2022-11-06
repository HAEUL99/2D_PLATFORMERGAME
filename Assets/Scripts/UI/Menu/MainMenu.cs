using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   public void PlayGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (PreviousInfo.instancepreviousInfo.numOfImg == 0)
        {
            SceneManager.LoadScene("LoadingScenFox");
        }
        if (PreviousInfo.instancepreviousInfo.numOfImg == 1)
        {
            SceneManager.LoadScene("LoadingScenCity");
        }
        if (PreviousInfo.instancepreviousInfo.numOfImg == 2)
        {
            SceneManager.LoadScene("LoadingScenBunny");
        }
    }

   public void QuitGame() {

        Debug.Log("QUIT");
        Application.Quit();
   }



}
