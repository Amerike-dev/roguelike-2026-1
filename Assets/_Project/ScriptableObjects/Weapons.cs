using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Scriptable Objects/Weapons")]
public class Weapons : ScriptableObject
{
    public int cooldown;
    public int damage;
    public int range;
    public int damp;
}
