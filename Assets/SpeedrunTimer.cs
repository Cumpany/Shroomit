using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedrunTimer : MonoBehaviour
{

    public bool EnableSpeedrunTimer = false;

    public GameObject speedRunTimer;

    void Update()
    {
        if (EnableSpeedrunTimer)
        {
            speedRunTimer.SetActive(true);
        }
        else if (!EnableSpeedrunTimer)
        {
            speedRunTimer.SetActive(false);
        }
    }
}
