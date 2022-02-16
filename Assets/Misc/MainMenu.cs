using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private string StartScene = "Start Scene";
    // [SerializeField] private string OptionScene = "Option Scene";
    static string LastScene;
    public AudioSource Music;
    private GameObject StartButton;
    void Awake()
    {
        StartButton = GameObject.Find("Button (start)");
    }
    void Start()
    {
        Music.loop = true;
        Music.Play();
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

    public void Credits()
    {
        SceneManager.LoadScene("EndCredits");
    }
    public static string PlayerName;
    public void SetName(string s)
    {
        PlayerName = s;
    }
}
