using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public WeaponType weaponType;
    public int damage;
    public SpriteRenderer gfx;

    public AudioSource sfx;
    public GameObject currentItemGO;
    public GameObject dropItemPrefab;
    public GameObject effect;

    public Transform attackPos;

    private Weapon currentWeapon;

    private void Update()
    {
        if (PlayerController.gameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PickUpWeapon();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void PickUpWeapon()
    {
        if (currentItemGO == null)
        {
            return;
        }

        DropWeapon();

        currentWeapon = currentItemGO.GetComponent<Item>().weapon;

        effect = currentWeapon.effects;
        sfx.clip = currentWeapon.audioClip;
        weaponType = currentWeapon.type;
        damage = currentWeapon.weaponDamage;
        gfx.sprite = currentWeapon.weaponSprite;

        if (!currentItemGO.GetComponent<Item>().unbreakable)
        {
            Destroy(currentItemGO);
        } else
        {
            currentItemGO = null;
        }
    }

    public void Attack()
    {
        if (effect != null)
        {
            GameObject vfx = Instantiate(effect, attackPos.position, transform.rotation);
            WeaponDamage weaponAttack = vfx.GetComponent<WeaponDamage>();
            sfx.Play();
            weaponAttack.weaponType = weaponType;
            weaponAttack.damage = damage;
        }
    }
    
    public void DropWeapon()
    {
        if (currentWeapon == null)
        {
            return;
        }

        sfx.clip = null;
        weaponType = WeaponType.None;
        damage = 5;
        gfx.sprite = null;
        Item newItem = Instantiate(dropItemPrefab, transform.position, Quaternion.identity).GetComponent<Item>();
        newItem.weapon = currentWeapon;
        newItem.countDown = true;
        currentWeapon = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            currentItemGO = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            currentItemGO = null;
        }
    }
}
