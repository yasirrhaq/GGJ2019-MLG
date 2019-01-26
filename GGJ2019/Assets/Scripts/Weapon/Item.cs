using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public SpriteRenderer itemSpriteRenderer;
    public Weapon weapon;
    public bool countDown = false;
    public float duration = 5f;

    void Start () {
        itemSpriteRenderer.sprite = weapon.weaponSprite;

        if (countDown)
        {
            Destroy(this.gameObject, duration);
        }
	}
}
