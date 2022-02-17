using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarrier : MonoBehaviour
{
    public Movement player;
    public GameObject BossTextManager;
    public GameObject Barrier;
    public GameObject BossHealth;
    public static GameObject Bar;
    public bool ActivateBossMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        Barrier.SetActive(false);
        Bar = Barrier;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivateBossMovement = true;
            FindObjectOfType<Movement>().CanMove = false;
            BossTextManager.SetActive(true);
            //FindObjectOfType<BossTextManager>().ActivateTextBox();
            Barrier.SetActive(true);
            Bar = Barrier;
            this.gameObject.SetActive(false);
            BossHealth.SetActive(true);
        }
    }
}
