using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrap : EnemyBehavior {
    
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
