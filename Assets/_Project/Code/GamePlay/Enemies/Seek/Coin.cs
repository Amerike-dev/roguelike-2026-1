using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Resources")]
    public Seek _seekMovement;

    [Header("Value")]
    public int value = 1; 

    [Header("Properties Seek")]
    public Transform player;
    public Transform coin;
    public float maxVelocity = 5f;
    public float viewRadius = 2f;

    public void Initialized()
    {
        _seekMovement = new Seek(coin, player, maxVelocity);
    }

    void Start()
    {
        coin = GetComponent<Transform>();
        Initialized();
    }

    void Update()
    {
        Seek();
    }

    public void Seek()
    {
        float distance = Vector2.Distance(player.position, coin.position);
        if (distance < viewRadius)
        {
            _seekMovement?.GetSteering();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
