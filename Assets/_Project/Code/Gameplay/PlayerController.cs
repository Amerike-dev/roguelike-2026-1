using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    [SerializeField] private Sprite capsuleSprite;
    
    private CombatManager combatManager;
    [SerializeField] private List<Weapons> weaponList = new List<Weapons>();
    [SerializeField] private int initialWeapon = 0;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
        
        
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        if(capsuleSprite != null) spriteRenderer.sprite = capsuleSprite;

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        gameObject.AddComponent<CapsuleCollider2D>();

        player = new Player(rb);
        
        combatManager = gameObject.AddComponent<CombatManager>();

        InitializeWeapon();
    }
    

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        HandleAnimation(horizontalInput, verticalInput);
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

    public void HandleAnimation(float horizontalInput, float verticalInput)
    {

        if (verticalInput > 0)
        {
            animator.SetBool(AnimationParameters.PlayerPar.walkUp, true);
            animator.SetBool(AnimationParameters.PlayerPar.walkDown, false);
        }
        else if (verticalInput < 0)
        {
            animator.SetBool(AnimationParameters.PlayerPar.walkDown, true);
            animator.SetBool(AnimationParameters.PlayerPar.walkUp, false);
        }
        else
        {
            animator.SetBool(AnimationParameters.PlayerPar.walkDown, false);
            animator.SetBool(AnimationParameters.PlayerPar.walkUp, false);
        }

        if (horizontalInput > 0)
        {
            animator.SetBool(AnimationParameters.PlayerPar.walkSide, true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            animator.SetBool(AnimationParameters.PlayerPar.walkSide, true);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            animator.SetBool(AnimationParameters.PlayerPar.walkSide, false);
        }
    }
}

public static class AnimationParameters
{
    public static class PlayerPar
    {
        public const string walkUp ="moveUp";
        public const string walkDown ="moveDown";
        public const string walkSide ="moveSide";
    }
}
