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
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            Debug.Log(StaticScript.Timer);
            t = StaticScript.Timer;
            Debug.Log(t);
            Debug.Log(t);
            GameObject.Find("TimerText").GetComponent<Text>().text = (t/50).ToString();
        }
    }
    private float t;
    private bool TimeSubmited = false;
    public void SubmitTime()
    {
        if (TimeSubmited)
        {
            return;
        }
        var d = new DcSend();
        d.Send($"**{(t/50).ToString()}** achieved by **{MainMenu.PlayerName}**");
        TimeSubmited = true;
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(PlayerName))
        {
            PlayerName = "Anonymous";
        }
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
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowIP(bool t)
    {
        StaticScript.PlayerIP = "127.0.0.1";
        if (!t)
        {
            StaticScript.PlayerIP = "127.0.0.1";
            Debug.Log("hiding player ip");
        }
        else
        {
            StaticScript.PlayerIP = null;
        }
        GameObject.Find("KrantuzLocation").SetActive(false);
    }
}
