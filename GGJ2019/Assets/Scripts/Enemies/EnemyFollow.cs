using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyBehavior {

    public float speed = 5;
    public bool move;
    private float waitTime;
    public float startWaitTime = .5f;

    public Pathfinding pathfinding;

    float step;
    Node currentNode;
    Vector2 targetNodepos;

    private void Start()
    {

    }

    void FixedUpdate () {
        if (move)
        {
            currentNode = pathfinding.grid.NodeFromWorldPoint(transform.position);

            bool found = false;
            foreach (Node neighbour in pathfinding.grid.GetNeighbours(currentNode))
            {
                if (pathfinding.path != null)
                    if (pathfinding.path.Contains(neighbour))
                    {
                        targetNodepos = new Vector2(neighbour.worldPosition.x, neighbour.worldPosition.y);
                        found = true;
                        break;
                    }
            }

            if (found)
            {
                step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetNodepos, step);
            }
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
            player.GameOver();

            Destroy(gameObject);
        }
    }
}
