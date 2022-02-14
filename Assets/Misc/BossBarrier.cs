using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarrier : MonoBehaviour
{

    public GameObject Barrier;
    // Start is called before the first frame update
    void Start()
    {
        Barrier.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Barrier.SetActive(true);
        }
    }
}
