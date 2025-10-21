using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public void Attack(Weapon currentWeapon)
    {
        if (currentWeapon == null)
        {
            Debug.Log("El player no tiene arma asignada");
            return;
        }
        currentWeapon.UseWeapon();
    }
}
