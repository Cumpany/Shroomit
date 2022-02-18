using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Loot;
    [SerializeField] private GameObject Loot2;
    public GameObject target;
    public float maxEnemyHP = 12.5f;
    public float enemyHP = 12.5f;
    private float iFrames = 0;

    private GameObject HpBar;
    void Start()
    {
        HpBar = this.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        DrawHP();
    }
    void DrawHP()
    {
        var healthBarImage = HpBar.GetComponent<Image>();
        healthBarImage.fillAmount = Mathf.Clamp(enemyHP / maxEnemyHP, 0, 1f);
        if (enemyHP <= 2.5)
        {
            healthBarImage.color = Color.red;
        }
        else if (enemyHP <= 5)
        {
            healthBarImage.color = Color.yellow;
        }
        else
        {
            healthBarImage.color = Color.green;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttackHitbox" && iFrames == 0 && gameObject.GetComponent<BoxCollider2D>().IsTouching(col))
        {
            iFrames = 30;
            Debug.Log("Enemy damage" + PlayerScript.PlayerDamage);
            enemyHP -= PlayerScript.PlayerDamage;
            DrawHP();
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
    void LateUpdate()
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
            PlayerScript.Gold++;
            if (maxEnemyHP > 15)
            {
                PlayerScript.Gold += 4;
            }
            Destroy(gameObject);
        }
    }
}
