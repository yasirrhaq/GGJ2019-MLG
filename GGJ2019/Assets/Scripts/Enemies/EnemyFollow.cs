using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyBehavior {

    public float speed = 5;
    public Transform playerTransform;

    public bool move;
    private float waitTime;
    public float startWaitTime = .5f;

    float step;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate () {
        if (move)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);
        }
        else
        {
            if (waitTime <= 0)
            {
                move = true;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void StopMove()
    {
        if (!move)
        {
            return;
        }

        waitTime = startWaitTime;
        move = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.Damage(damage);
            Debug.Log("Eww");

            Destroy(gameObject);
        }
    }
}
