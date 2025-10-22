using UnityEngine;

public enum WeaponType { Range, MidRange, Melee, Special }
public class Weapon
{
    private Weapons scriptable;
    
    /*public string name;
    public float damage;
    public WeaponType weaponType;*/

    public Weapon(Weapons scriptable)
    {
        this.scriptable = scriptable;
    }

    public virtual void UseWeapon()
    {
        Debug.Log("La arma llamada " + scriptable.weaponName + " hace un dano de " + scriptable.damage + " y es de tipo " + scriptable.weaponType);
    }
}
