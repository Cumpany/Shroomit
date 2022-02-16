using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public float maxEnemyHP = 50f;
    public static float enemyHP = 50f;
    private float iFrames = 0;
    [SerializeField] private GameObject HpBar;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DrawHP();
    }
    public static void Damage(float d)
    {
        enemyHP -= d;
        Debug.Log(enemyHP);
    }
    void DrawHP()
    {
        var healthBarImage = HpBar.GetComponent<Image>();
        healthBarImage.fillAmount = Mathf.Clamp(enemyHP / maxEnemyHP, 0, 1f);
        if (enemyHP <= 12.5)
        {
            healthBarImage.color = Color.red;
        }
        else if (enemyHP <= 25)
        {
            healthBarImage.color = Color.yellow;
        }
        else
        {
            healthBarImage.color = Color.green;
        }
    }
    public Collider2D AttackHitbox;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col == AttackHitbox && iFrames == 0)
        {
            iFrames = 30;
            Debug.Log("boss damage" + PlayerScript.PlayerDamage);
            enemyHP -= PlayerScript.PlayerDamage;
            DrawHP();
        }
    }
    float horizontal;
    float vertical;
    void Update()
    {
        horizontal = rb.velocity.x;
        vertical = rb.velocity.y;
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }
        if (horizontal > 0)
        {
            ChangeAnim("right");
        }
        else if (horizontal < 0)
        {
            ChangeAnim("left");
        }

        if (vertical > 0)
        {
            ChangeAnim("up");
        }
        else if (vertical < 0)
        {
            ChangeAnim("down");
        }

        if (horizontal == 0 && vertical == 0)
        {
            ChangeAnim("idle");
        }
    }
    public Animator animator;
    public static int Direction;
    void ChangeAnim(string d)
    {
        animator.SetBool("IsWalkingDown", false);
        animator.SetBool("IsWalkingUp", false);
        animator.SetBool("IsWalkingRight", false);
        animator.SetBool("IsWalkingLeft", false);
        switch (d)
        {
            case "idle":
                break;
            case "up":
            Direction = 1;
            animator.SetBool("IsWalkingUp", true);
                break;
            case "down":
            Direction = 3;
            animator.SetBool("IsWalkingDown", true);
                break;
            case "right":
            Direction = 2;
            animator.SetBool("IsWalkingRight", true);
                break;
            case "left":
            Direction = 4;
            animator.SetBool("IsWalkingLeft", true);
                break;
            default:
            Debug.LogError("fucking idiot, wrong input to animation");
                break;
        }
        // animator.SetInteger("LastDirection", Direction - 1);
    }
}
