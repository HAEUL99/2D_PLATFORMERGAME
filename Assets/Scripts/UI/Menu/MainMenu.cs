using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("clickbtn");
        Invoke("Play", 0.3f);
    }

    public void Play()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void QuitGame()
     {

        FindObjectOfType<AudioManager>().Play("clickbtn");
        Invoke("quitInvoke", 0.3f);
        
     }

    public void Option()
    {
        FindObjectOfType<AudioManager>().Play("clickbtn");
    }

    public void quitInvoke()
    {
        Application.Quit();
    }


}
