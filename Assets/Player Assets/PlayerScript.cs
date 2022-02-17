using System.Threading;
using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;

    public AudioSource Hurt;

    public static int Gold;

    static public float health = 100, maxHealth = 100;
    static float iFrames = 0;
    public static float aFrames = 0;
    public Image healthBarImage;
    public static float PlayerDamage = 10/3;
    [SerializeField] private GameObject AttackHitbox;
    void Start()
    {
        if (string.IsNullOrEmpty(MainMenu.PlayerName))
        {
            MainMenu.PlayerName = "Anonymous";
        }
        if (SaveManager.IsSaveFile())
        {
            SaveManager.StaticLoad();
        }
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            Gold++;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Damage(10);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveManager.Save();
            SceneManager.LoadScene("MainMenu");
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
            AttackHitbox.transform.position = new Vector3(0,-100,0);
        }
    }
    Vector3 a;
    public void Attack()
    {
        for (var i = 0; i < 9; i++)
        {
            if (PlayerInventory.Inv[i] == (ItemList.Items)5)
            {
                PlayerDamage = (10/3)*2;
                break;
            }
            else
            {
                PlayerDamage = 10/3;
            }
        }
        if (aFrames == 0)
        {
            animator.SetBool("IsAttacking", true);
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
                SaveManager.DeleteSave();
                SceneManager.LoadScene("MainMenu");
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
