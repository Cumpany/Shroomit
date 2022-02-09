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
    [SerializeField] private string OptionScene = "Option Scene";
    static string LastScene;

    public AudioSource audioSource;
    public void StartGame()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(StartScene);
    }
    public void Options()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(OptionScene);
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
    public AudioSource a;
    public void TestSound()
    {
        a.Play();
    }

    public void SoundTest()
    {
        audioSource.Play();
    }
}
