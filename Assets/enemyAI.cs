using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//KUK :D
public class enemyAI : MonoBehaviour
{
    [HideInInspector]
    public bool hasTarget = false;

    public GameObject target;
    public GameObject enemy;

    private Rigidbody2D rb;

    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasTarget == true)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            follow(target.transform, enemy.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = col.gameObject;
            hasTarget = true;   
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = null;
            hasTarget = false;
        }
    }

    private void follow(Transform target, Transform enemy)
    {
        rb.AddForce((target.transform.position - enemy.transform.position).normalized * speed);
    }
}
