using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EscEvnt : MonoBehaviour
{
    /*
    //① 이벤트 생성을 위한 대리자 하나 생성
    public delegate void EventHandler(); //메서드를 여러 개 등록 후 호출 가능

    //② 이벤트 선언: Click 이벤트
    public event EventHandler Esc_Click;

    //③ 이벤트 발생 메서드: OnClick 이벤트 처리기(핸들러) 생성
    public void OnEscClick()
    {
        if (Esc_Click != null) //이벤트에 등록된 값이 있는지 확인(생략 가능)
        {
            Esc_Click();    //대리자 형식의 이벤트 수행
        }
    }
    */

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

            PressEsc();

        }
    }

    private void PressEsc()
    {
        if (CanseeUI == false)
        {
            escUI.SetActive(true);
            Time.timeScale = 0f;
            CanseeUI = true;

        }
        else
        {
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
        SceneManager.LoadScene("Game Scenes/Lobby");
    }

}
