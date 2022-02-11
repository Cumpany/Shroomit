using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Loot;
    public GameObject target;

    public float enemyHP = 10;
    private float iFrames = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttackHitbox" && iFrames == 0)
        {
            iFrames = 30;
            Debug.Log("Enemy damage" + PlayerScript.PlayerDamage);
            enemyHP -= PlayerScript.PlayerDamage;
        }
    }
    void FixedUpdate()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
