using UnityEngine;

public enum WeaponType { Range, MidRange, Melee, Special }
public class Weapon
{
    private Weapons scriptable;
    
    private Transform playerTransform;
    private LayerMask enemyLayer;

    public string Name
    {
        get
        {
            return scriptable.weaponName;
        }
    }

    public Weapon(Weapons scriptable)
    {
        this.scriptable = scriptable;
    }

    public void Setup(Transform playerT, LayerMask enemyL)
    {
        this.playerTransform = playerT;
        this.enemyLayer = enemyL;
    }
    
    public virtual void UseWeapon(int attackCode)
    {
        if (playerTransform == null)
        {
            Debug.LogError("El arma no se ha configurado con el Transform del jugador. ¡Llama a Setup()!");
            return;
        }
        Debug.Log("La arma llamada " + scriptable.weaponName + " hace un dano de " + scriptable.damage + " y es de tipo " + scriptable.weaponType);
        Vector2 finalAttackDirection = Vector2.zero;
        
        Vector2 horizontalDir = playerTransform.right * Mathf.Sign(playerTransform.localScale.x);

        switch (attackCode)
        {
            case 1:
                finalAttackDirection = horizontalDir;
                break;
            case 2:
                finalAttackDirection = Vector2.up;
                break;
            case 3:
                finalAttackDirection = Vector2.down;
                break;
            default:
                finalAttackDirection = Vector2.down; 
                break;
        }
        
        Vector2 attackPos = (Vector2)playerTransform.position + finalAttackDirection * scriptable.range;
        
        Debug.DrawRay(attackPos, finalAttackDirection * 0.1f, Color.red, 0.5f);
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, scriptable.damp, enemyLayer);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            var enemyHealth = enemy.GetComponent<EnemyHealth>(); 
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(scriptable.damage); 
                Debug.Log("Daño infligido a " + enemy.gameObject.name);
            }
        }
    }
}
