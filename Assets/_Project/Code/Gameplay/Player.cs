using System.Collections.Generic;
using UnityEngine;

public enum PlayerCondition { Normal, Dizzy, Poison }
public class Player
{
    public float baseSpeed;
    public float humidity;
    public PlayerCondition playerCondition;
    public Weapon currentWeapon;
    public bool invertInput;
    public List<Collectable> collectables;

    public float permanentCollectableSpeed;
    public float bossWeaponSpeedModifier;
    
    private Rigidbody2D rb;
    
    public Player(Rigidbody2D rb, float baseSpeed = 5f, float humidity = 200f, PlayerCondition initialCondition = PlayerCondition.Normal, List<Collectable> initialCollectables = null)
    {
        this.rb = rb;
        this.baseSpeed = baseSpeed;
        this.humidity = humidity;
        this.playerCondition = initialCondition;
        this.collectables = initialCollectables ?? new List<Collectable>();
        
        this.invertInput = false;
    }

    public void PlayerMovement(float horizontalInput, float verticalInput)
    {
        float finalSpeed = ChangeSpeed();

        if (playerCondition == PlayerCondition.Dizzy && invertInput)
        {
            horizontalInput *= -1;
            verticalInput *= -1;
        }
        
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * finalSpeed;
        rb.linearVelocity = movement;
    }

    public float ChangeSpeed()
    {
        float finalSpeed = baseSpeed;
        finalSpeed += permanentCollectableSpeed;
        finalSpeed += bossWeaponSpeedModifier;

        float humidityThreshold = 50f;

        if (humidity < humidityThreshold)
        {
            float reduction = 1f - (humidity / humidityThreshold);
            float maxReduction = baseSpeed - 1f;
            finalSpeed -= maxReduction * reduction;
        }

        switch (playerCondition)
        {
            case PlayerCondition.Normal:
                break;
            case PlayerCondition.Dizzy:
                finalSpeed -= 1f;
                break;
            case PlayerCondition.Poison:
                finalSpeed -= 3f;
                break;
        }
        
        return Mathf.Clamp(finalSpeed, 1f, 15f);
    }
}
