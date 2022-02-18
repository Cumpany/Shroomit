using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTriggerScript : MonoBehaviour
{

    public GameObject ForestBarrier;
    // Start is called before the first frame update
    void Start()
    {
        ForestBarrier.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ForestBarrier.SetActive(false);
        }
    }
}
