using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private GameObject playerGO;
    [SerializeField] private Sprite capsuleSprite;
    
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
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Atacando ando");
        }
    }
}
