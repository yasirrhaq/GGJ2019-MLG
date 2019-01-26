using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public string name;
    public int health;
    public int damage;
    public int point;
    public EnemyType type;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    
    public void Die()
    {
        ScoreManager.instance.AddScore(point);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
}

public enum EnemyType
{
    None,
    Lemak,
    Debu,
    Serangga
}
