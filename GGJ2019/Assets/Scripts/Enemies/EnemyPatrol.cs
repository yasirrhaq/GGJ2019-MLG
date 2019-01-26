using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyBehavior {
    public float speed = 4f;

    private float waitTime;
    public float startWaitTime;

    public Transform[] waypoints;
    private int currentWaypointIndex;

    Vector2 direction;

    private void Start()
    {
        waitTime = startWaitTime;
        currentWaypointIndex = 1;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);        

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (currentWaypointIndex < waypoints.Length - 1)
                {
                    currentWaypointIndex++;
                } else
                {
                    currentWaypointIndex = 0;
                }

                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        } else
        {
            UpdateRotation();
        }
    }

    public void UpdateRotation()
    {
        direction = waypoints[currentWaypointIndex].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.Damage(damage);
            Debug.Log("Iiiiii");
        }
    }
}
