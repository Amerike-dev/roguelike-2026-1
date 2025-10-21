using UnityEngine;

public enum WeaponType { Range, MidRange, Melee, Special }
public class Weapon
{
    public string name;
    public float damage;
    public WeaponType weaponType;

    public virtual void UseWeapon()
    {
        Debug.Log("La arma llamada " + name + " hace un dano de " + damage + " y es de tipo " + weaponType);
    }
}
