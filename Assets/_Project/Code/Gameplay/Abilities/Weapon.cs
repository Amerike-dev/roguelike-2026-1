using UnityEngine;

public enum WeaponType { Range, MidRange, Melee, Special }
public class Weapon
{
    public string name;
    public float damage;
    public WeaponType weaponType;
}
