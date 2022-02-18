using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private GameObject TimerObject;
    void FixedUpdate()
    {
        StaticScript.Timer++;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            TimerObject.GetComponent<Text>().text = F();
        }
    }
    string F()
    {
        TimeSpan t = TimeSpan.FromSeconds( StaticScript.Timer/50 );

        string answer = string.Format("{0:D2}:{1:D2}.{2:D3}", 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
        return answer;
    }
}
