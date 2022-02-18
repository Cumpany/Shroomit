using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public static float maxEnemyHP = 100f;
    public static float enemyHP = 100f;
    private float iFrames = 0;
    [SerializeField] private GameObject HpBar;
    [SerializeField] Rigidbody2D rb;
    Transform player;

    float speed = 400f;

    public BossBarrier Bossbarrier;
    public BossTextManager bossTextManager;
    public PlayerScript PlayerScript;

  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        DrawHP();
        Vector3 vel = new Vector3(rb.velocity.x, rb.velocity.y);
    }
    public static void Damage(float d)
    {
        enemyHP -= d;
        Debug.Log("boss hp: " + enemyHP);
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
            Debug.Log("boss damage" + PlayerScript.PlayerDamage.ToString());
            enemyHP -= PlayerScript.PlayerDamage;
            DrawHP();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerScript.Damage(20);
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerScript.Damage(10);
            float h = player.transform.position.x - rb.position.x;
            float v = player.transform.position.y - rb.position.y;
            Debug.Log("H: " + h + " V: " + v);
            animator.SetTrigger("IsAttacking");
            if (h > 0 && v > 0 && h > v)
            {
                animator.SetInteger("AttackDirection", 2);
            }
            else if (h > 0 && v > 0 && h < v)
            {
                animator.SetInteger("AttackDirection", 1);
            }
            else if (h < 0 && v > 0 && -h > v)
            {
                animator.SetInteger("AttackDirection", 4);
            }
            else if (h < 0 && v > 0 && -h < v)
            {
                animator.SetInteger("AttackDirection", 1);
            }
            else if (h > 0 && v < 0 && h > -v)
            {
                animator.SetInteger("AttackDirection", 2);
            }
            else if (h < 0 && v < 0 && -h > -v)
            {
                animator.SetInteger("AttackDirection", 4);
            }
            else
            {
                animator.SetInteger("AttackDirection", 3);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.ResetTrigger("IsAttacking");
        }
    }

    float horizontal;
    float vertical;
    void Update()
    {
        if (enemyHP <= 0)
        {
            SaveManager.DeleteSave();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void FixedUpdate()
    {
        
        horizontal = rb.velocity.x;
        vertical = rb.velocity.y;
        if (iFrames > 0)
        {
            iFrames--;
        }
        

        if (horizontal > 0 && horizontal > vertical)
        {
            ChangeAnim("right");
        }
        else if (horizontal < 0 !& horizontal > vertical)
        {
            ChangeAnim("down");
        }

        if (vertical > 0 && vertical > horizontal)
        {
            ChangeAnim("up");
        }
        else if (vertical < 0 !& vertical > horizontal)
        {
            ChangeAnim("left");
        }

        
        if (horizontal == 0 && vertical == 0)
        {
            ChangeAnim("idle");
        }


        if (Bossbarrier.ActivateBossMovement == true && bossTextManager.BossCanMove)
        {
            follow(player.transform, gameObject.transform);
        }


        if (enemyHP < 50)
        {
            speed = 650f;
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

    private void follow(Transform target, Transform enemy)
    {
        rb.AddForce((target.transform.position - enemy.transform.position).normalized * speed);
    }

    public static IEnumerator Wait(int i)
    {
        yield return new WaitForSeconds(i);
    }
}
