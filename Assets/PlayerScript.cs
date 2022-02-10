using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;

    static public float health = 100, maxHealth = 100;
    static float iFrames = 0;
    public Image healthBarImage;
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
    }
    void FixedUpdate()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }
    }
    public void Damage(float d)
    {
        if (iFrames <= 0)
        {
            Debug.Log($"took {d} damgaeg");
            health -= d;
            UpdateHealthBar();
            if (health <= 0)
            {
                Application.Quit(69420);
                //EditorApplication.Exit(69);
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
