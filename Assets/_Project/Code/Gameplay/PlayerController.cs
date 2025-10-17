using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    public Player player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite capsuleSprite;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = new Player(rb);
        rb.gravityScale = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(capsuleSprite != null) spriteRenderer.sprite = capsuleSprite;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        player.PlayerMovement(horizontalInput, verticalInput);
    }
}
