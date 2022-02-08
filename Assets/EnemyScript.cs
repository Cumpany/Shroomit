using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Loot;
    public float enemyHP = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Enemy HP:" + enemyHP);
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
