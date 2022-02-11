using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Loot;
    [SerializeField] private GameObject Loot2;
    public GameObject target;

    public float enemyHP = 10;
    private float iFrames = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttackHitbox" && iFrames == 0 && gameObject.GetComponent<BoxCollider2D>().IsTouching(col))
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
            if (Loot != null)
            {
                var i = Instantiate(Loot);
                i.transform.position = gameObject.transform.position;
                i.transform.position = 
                new Vector3(gameObject.transform.position.x-0.1f,gameObject.transform.position.y-0.1f,Loot.transform.position.z);
            }
            if (Loot2 != null)
            {
                var j = Instantiate(Loot2);
                j.transform.position = gameObject.transform.position;
                j.transform.position = 
                new Vector3(gameObject.transform.position.x+0.1f,gameObject.transform.position.y+0.1f,Loot2.transform.position.z);
            }
            Destroy(gameObject);
        }
    }
}
