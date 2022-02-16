using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static float Timer;
    [SerializeField] private GameObject TimerObject;
    void FixedUpdate()
    {
        Timer++;
        TimerObject.GetComponent<Text>().text = (Timer/50).ToString();
    }
}
