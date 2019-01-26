using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public WeaponType weaponType;
    public int damage;
    public SpriteRenderer gfx;

    public GameObject currentItemGO;
    public GameObject dropItemPrefab;

    private Weapon currentWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickUpWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropWeapon();
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

        weaponType = currentWeapon.type;
        damage = currentWeapon.weaponDamage;
        gfx.sprite = currentWeapon.weaponSprite;

        Destroy(currentItemGO);
    }

    public void DropWeapon()
    {
        if (currentWeapon == null)
        {
            return;
        }

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
