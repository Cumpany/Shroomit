using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarrier : MonoBehaviour
{
    public GameObject BossTextManager;
    public GameObject Barrier;
    public GameObject BossHealth;
    public static GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
        Barrier.SetActive(false);
        Bar = Barrier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            BossTextManager.SetActive(true);
            //FindObjectOfType<BossTextManager>().ActivateTextBox();
            Barrier.SetActive(true);
            Bar = Barrier;
            this.gameObject.SetActive(false);
            BossHealth.SetActive(true);
        }
    }
}
