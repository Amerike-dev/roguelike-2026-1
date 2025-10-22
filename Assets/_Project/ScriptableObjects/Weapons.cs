using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Scriptable Objects/Weapons")]
public class Weapons : ScriptableObject
{
    public string weaponName;
    
    public int cooldown;
    public int damage;
    public int range;
    public int damp;

    public WeaponType weaponType;
}
