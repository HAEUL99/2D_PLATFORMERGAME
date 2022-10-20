using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    const string savedOption = "SavedResolution";

    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height + 
                "@" + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (option == LoadPrefs()) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SavePrefs(string o) {
        PlayerPrefs.SetString(savedOption, o);
        PlayerPrefs.Save();
    }

    public string LoadPrefs() {
        string res = PlayerPrefs.GetString(savedOption, "800x600@60hz");
        return res;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];

        SavePrefs(resolution.width + "x" + resolution.height);
        
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

}
