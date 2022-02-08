using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string StartScene = "Start Scene";
    [SerializeField] private string OptionScene = "Option Scene";
    static string LastScene;
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
        EditorApplication.Exit(0);
    }
}
