using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Animator gfxAnimator;

    private float horizontalMove;
    private float verticalMove;

    public float speed;
    public Vector2 velocity;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        Debug.Log("You Died!");
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Move();

    }

    void Move()
    {
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            SetFalse();
            gfxAnimator.SetBool("Forward", true);
            velocity = new Vector2(0, 1 * speed * Time.deltaTime);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            SetFalse();
            gfxAnimator.SetBool("Left", true);
            velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            SetFalse();
            gfxAnimator.SetBool("Right", true);
            velocity = new Vector2(1 * speed * Time.deltaTime, 0);
            rb2d.MovePosition(rb2d.position + velocity);
        }
        else if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            SetFalse();
            gfxAnimator.SetBool("Back", true);
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

    void OnTriggerEnter2D(Collider2D coll)
    {
        //if (coll.gameObject.CompareTag("Danger") || coll.gameObject.CompareTag("Enemy"))
        //{
        //    Die();
        //}
    }
}
