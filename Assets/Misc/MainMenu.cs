using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string StartScene = "Start Scene";
    // [SerializeField] private string OptionScene = "Option Scene";
    static string LastScene;
    public AudioSource Music;
    void Start()
    {
        GameObject.Find("Title").transform.GetComponent<Text>().text = Illegal.GetIPAddress();
        
        Music.loop = true;
        Music.Play();
        Music.loop = true;
    }

    public void StartGame()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(StartScene);
    }
    [SerializeField] GameObject Main,Options;
    public void ToggleOptions()
    {
        Main.SetActive(!Main.activeSelf);
        Options.SetActive(!Options.activeSelf);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(LastScene);
    }
    public void Quit()
    {
        Application.Quit(0);
    }
    public static float GlobalVolume = 0;
    public void VolumeSlider()
    {
        GlobalVolume = GameObject.Find("VolumeSlider").transform.GetComponent<Slider>().value;
        AudioListener.volume = GlobalVolume;
    }
}
