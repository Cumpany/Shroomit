using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTriggerScript : MonoBehaviour
{
    public GameObject miniboss;

    public GameObject ForestBarrier;
    // Start is called before the first frame update
    void Start()
    { 
        ForestBarrier.SetActive(true);
    }

    void Update()
    {
        if (miniboss.GetComponent<EnemyScript>().enemyHP <= 0)
        {
            ForestBarrier.SetActive(false);
        }
    }
}
