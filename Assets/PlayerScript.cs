using System.Threading;
using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;

    public AudioSource Hurt;

    static public float health = 100, maxHealth = 100;
    static float iFrames = 0;
    static float aFrames = 0;
    public Image healthBarImage;
    public static int PlayerDamage = 5;
    [SerializeField] private GameObject AttackHitbox;
    void Start()
    {
        // Debug.Log($"{Screen.width} {Screen.height}");
        if ((float)((float)Screen.width / (float)Screen.height) > 1.75f && (float)((float)Screen.width / (float)Screen.height) < 1.8f)
        {
            // Debug.Log("didnt move HB    " + (float)((float)Screen.width / (float)Screen.height));
        }
        else
        {
            // Debug.Log("moved HB    " + (float)((float)Screen.width / (float)Screen.height));
            GameObject.Find("HB").GetComponent<RectTransform>().position = new Vector3(1.1f, 6, 0);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Damage(10);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void FixedUpdate()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }
        if (aFrames > 0)
        {
            aFrames--;
        }
        if (aFrames == 20)
        {
            AttackHitbox.transform.position = new Vector3(0,0,0);
        }
    }
    Vector3 a;
    public void Attack()
    {
        if (aFrames == 0)
        {
            switch (Movement.Direction)
            {
                case 1:
                a = new Vector3(0,1,0);
                    break;
                case 2:
                a = new Vector3(1,0,0);
                    break;
                case 3:
                a = new Vector3(0,-1,0);
                    break;
                case 4:
                a = new Vector3(-1,0,0);
                    break;
                default:
                Debug.LogError("Somethings wrong, i can feel it");
                    break;
            }
            
            AttackHitbox.transform.localPosition = 
            GameObject.FindGameObjectWithTag("Player").transform.position + a;
            aFrames = 30;
        }
    }
    public void Damage(float d)
    {
        if (iFrames <= 0)
        {
            Debug.Log($"took {d} damgaeg");
            health -= d;
            Hurt.Play();
            Hurt.loop =false;
            UpdateHealthBar();
            if (health <= 0)
            {
                Application.Quit(69420);
            }
            iFrames = 30; // time between being able to take damage
        }
    }
    public void UpdateHealthBar() 
    {
        healthBarImage.fillAmount = Mathf.Clamp(PlayerScript.health / PlayerScript.maxHealth, 0, 1f);
        if (health < 15)
        {
            healthBarImage.color = Color.red;
        }
        else if (health < 50)
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
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("hahah gay");
            Damage(10);
        } 
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Damage(10);
        } 
    }
}
