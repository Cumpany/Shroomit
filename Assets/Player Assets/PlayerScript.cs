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
    public static float PlayerDamage = 0;
    [SerializeField] private GameObject AttackHitbox;
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            StaticScript.Timer = 0;
        }
        if (string.IsNullOrEmpty(MainMenu.PlayerName))
        {
            MainMenu.PlayerName = "Anonymous";
            Debug.Log("player did not input name so defaulted to Anonymous");
        }
        if (SaveManager.IsSaveFile())
        {
            Debug.Log("detected save file so trying to load it");
            SaveManager.StaticLoad();
        }
        // Debug.Log($"{Screen.width} {Screen.height}");
        if ((float)((float)Screen.width / (float)Screen.height) > 1.75f && (float)((float)Screen.width / (float)Screen.height) < 1.8f)
        {
            Debug.Log("didnt move HB    " + (float)((float)Screen.width / (float)Screen.height));
        }
        else
        {
            Debug.Log("moved HB    " + (float)((float)Screen.width / (float)Screen.height));
            GameObject.Find("HB").GetComponent<RectTransform>().position = new Vector3(1.1f, 6, 0);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.LogWarning("idiot pressed L");
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
            Debug.Log("pressed escape, trying to save");
            SaveManager.Save();
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Y))
        {
            Debug.LogWarning("GodMode. Have fun");
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            PlayerScript.health = float.MaxValue;
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
            if (PlayerInventory.Inv[i] == (ItemList.Items)7)
            {
                PlayerDamage = 69.420f;
                break;
            }
            else if (PlayerInventory.Inv[i] == (ItemList.Items)8)
            {
                PlayerDamage = 10f;
                break;
            }
            else if (PlayerInventory.Inv[i] == (ItemList.Items)6)
            {
                PlayerDamage = 5f;
                break;
            }
            else if (PlayerInventory.Inv[i] == (ItemList.Items)5)
            {
                PlayerDamage = 2.5f;
                break;
            }
            else
            {
                PlayerDamage = 0;
            }
        }
        Debug.Log(PlayerDamage);
        if (aFrames == 0 && PlayerDamage != 0)
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
                Debug.LogWarning("player died, deleting save file nerd");
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
            Debug.Log("hahah gay player took 10 damgea");
            Damage(20);
        } 
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("gay ass player stayed with the enemy and took 10 ddamagbuer");
            Damage(10);
        } 
    }
}
