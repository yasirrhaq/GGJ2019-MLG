using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {

    public WeaponType weaponType;
    public float duration = 2f;
    public int damage;

    private void Start()
    {
        Destroy(gameObject, duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();

            if (enemy.type == EnemyType.Debu && weaponType == WeaponType.Sapu)
            {
                enemy.health -= damage;
                Debug.Log(enemy.name + " " + enemy.health);
            } else if (enemy.type == EnemyType.Lemak && weaponType == WeaponType.Sabun)
            {
                enemy.health -= damage;
                EnemyFollow enemyFollow = enemy.gameObject.GetComponent<EnemyFollow>();
                enemyFollow.StopMove();
                Debug.Log(enemy.name + " " + enemy.health);
            } else if (enemy.type == EnemyType.Serangga && weaponType == WeaponType.Raket)
            {
                enemy.health -= damage;
                Debug.Log(enemy.name + " " + enemy.health);
            }

        }
    }
}
