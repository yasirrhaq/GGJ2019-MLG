using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static Transform playerTransform;
    public static bool gameOver;

    public float maxHealth = 100;
    public float health = 100;
    public Image healthBar;
    public float addSpeed = 1;

    float targetValue;
    bool isUpdatingValue;
    bool increase;

    public Animator gfxAnimator;

    public GameObject gameOverObj;

    private float horizontalMove;
    private float verticalMove;

    public float speed;
    public Vector2 velocity;
    private Rigidbody2D rb2d;

    void Awake()
    {
        playerTransform = transform;
    }
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (isUpdatingValue)
        {
            if (increase)
            {
                if (targetValue > healthBar.fillAmount)
                {
                    healthBar.fillAmount += addSpeed * Time.deltaTime;

                    if (healthBar.fillAmount > targetValue)
                    {
                        healthBar.fillAmount = targetValue;
                        isUpdatingValue = false;
                    }
                }
            }
            else
            {
                if (targetValue < healthBar.fillAmount)
                {
                    healthBar.fillAmount -= addSpeed * Time.deltaTime;

                    if (healthBar.fillAmount < targetValue)
                    {
                        healthBar.fillAmount = targetValue;
                        isUpdatingValue = false;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");
            Move();
        }
    }

    void Move()
    {
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            SetFalse();
            gfxAnimator.SetTrigger("Forward");
            velocity = new Vector2(0, 1 * speed * Time.deltaTime);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            SetFalse();
            gfxAnimator.SetTrigger("Left");
            velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            SetFalse();
            gfxAnimator.SetTrigger("Right");
            velocity = new Vector2(1 * speed * Time.deltaTime, 0);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        else if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            SetFalse();
            gfxAnimator.SetTrigger("Back");
            velocity = new Vector2(0, -1 * speed * Time.deltaTime);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
        {
            SetFalse();
        }
    }

    public void SetFalse(bool forward = true, bool backward = true, bool left = true, bool right = true)
    {
        if (forward)
        {
            gfxAnimator.SetBool("Forward", false);
        }

        if (backward)
        {
            gfxAnimator.SetBool("Back", false);
        }

        if (left)
        {
            gfxAnimator.SetBool("Left", false);
        }

        if (right)
        {
            gfxAnimator.SetBool("Right", false);
        }
    }
    
    public void Heal(float healPoint)
    {
        increase = true;
        health += healPoint;
        UpdateHealthBar();
    }

    public void Damage(float damagePoint)
    {
        increase = false;
        health -= damagePoint;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        targetValue = health / maxHealth;
        isUpdatingValue = true;
    }

    public void GameOver()
    {
        if (health <= 0)
        {
            //play gameover music

            gameOver = true;
            Debug.Log("Game Over");

            if (gameOverObj != null)
                gameOverObj.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //if (coll.gameObject.CompareTag("Danger") || coll.gameObject.CompareTag("Enemy"))
        //{
        //    Die();
        //}
    }
}
