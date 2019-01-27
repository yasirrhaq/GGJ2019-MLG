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

    public Item[] dropItems;

    public bool destroyParent;
    public GameObject dieEffect;
    
    public void Die()
    {
        ScoreManager.instance.AddScore(point);

        if (dieEffect != null)
        {
            GameObject vfx = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(vfx, 1.5f);
        }

        if (dropItems != null)
        {
            int rand = Random.Range(0, 7);

            if (rand > -1 && rand < dropItems.Length)
            {
                Instantiate(dropItems[rand], transform.position, Quaternion.identity).GetComponent<Item>();
            }
        }

        if (destroyParent)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
