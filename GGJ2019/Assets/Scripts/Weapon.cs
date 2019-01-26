using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class Weapon : ScriptableObject {

    public string weaponName;
    public WeaponType type;
    public Sprite weaponSprite;
    public int weaponDamage = 10;
    public GameObject effects;

}

public enum WeaponType
{
    Sabun,
    Raket,
    Sapu,
    None
}
