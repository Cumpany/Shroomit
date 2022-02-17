using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private GameObject TimerObject;
    void FixedUpdate()
    {
        StaticScript.Timer++;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            TimerObject.GetComponent<Text>().text = (StaticScript.Timer/50).ToString();
        }
    }
}
