using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Photon.Pun;

public class EscEvnt : MonoBehaviour
{


    [SerializeField]
    private GameObject escUI;
    private bool CanseeUI;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        escUI.SetActive(false);
        CanseeUI = false;

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height + 
                "@" + resolutions[i].refreshRate + "hz";
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("clickbtn");
            PressEsc();

        }
    }

    private void PressEsc()
    {
        if (CanseeUI == false)
        {
            FindObjectOfType<AudioManager>().Play("clickbtn");
            escUI.SetActive(true);
            Time.timeScale = 0f;
            CanseeUI = true;

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("clickbtn");
            escUI.SetActive(false);
            Time.timeScale = 1f;
            CanseeUI = false;
        }
    }

    public void ResumeBtn()
    {
        escUI.SetActive(false);
        Time.timeScale = 1f;
        CanseeUI = false;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void LeaveBtn()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Game Scenes/Main Menu");

    }

}
