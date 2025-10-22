using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private GameObject playerGO;
    [SerializeField] private Sprite capsuleSprite;
    
    private CombatManager combatManager;
    [SerializeField] private List<Weapons> weaponList = new List<Weapons>();
    [SerializeField] private int initialWeapon = 0;
    
    void Start()
    {
        playerGO = new GameObject("Player");
        playerGO.transform.parent = transform;
        
        SpriteRenderer spriteRenderer = playerGO.AddComponent<SpriteRenderer>();
        if(capsuleSprite != null) spriteRenderer.sprite = capsuleSprite;

        rb = playerGO.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        playerGO.AddComponent<CapsuleCollider2D>();

        player = new Player(rb);
        
        combatManager = playerGO.AddComponent<CombatManager>();

        InitializeWeapon();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        player.PlayerMovement(horizontalInput, verticalInput);
        
        SystemCombat();
    }

    private void SystemCombat()
    {
        if(combatManager == null) return;
        
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Atacando con el arma " + player.currentWeapon.Name);
            combatManager.Attack(player.currentWeapon);
        }
    }

    private void InitializeWeapon()
    {
        if (weaponList.Count == 0)
        {
            Debug.Log("No hay weapons listadas");
            return;
        }
        
        int maxIndex = weaponList.Count - 1;
        int index = Mathf.Clamp(initialWeapon, 0, maxIndex);

        Weapons weaponSelected = weaponList[index];

        player.currentWeapon = new Weapon(weaponSelected);
    }
}
