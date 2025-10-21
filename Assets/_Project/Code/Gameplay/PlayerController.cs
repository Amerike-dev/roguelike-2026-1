using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private GameObject playerGO;
    [SerializeField] private Sprite capsuleSprite;
    
    private CombatManager combatManager;
    
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

        player.currentWeapon = new Spear();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        player.PlayerMovement(horizontalInput, verticalInput);
        
        SystemCombat();
    }

    public void SystemCombat()
    {
        if(combatManager == null) return;
        
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Atacando ando");
            combatManager.Attack(player.currentWeapon);
        }
    }
}
