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
    void Update()
    {
        if (hasTarget == true)
        {
            Debug.Log("hasTarget");
            float distance = Vector3.Distance(transform.position, target.transform.position);
            follow(target.transform, enemy.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("gay");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Gay2");
            target = col.gameObject;
            Debug.Log(target.name);
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
        Debug.Log("hejlkjsdfijsdf");
        rb.AddForce((target.transform.position - enemy.transform.position).normalized * speed);
    }
}
