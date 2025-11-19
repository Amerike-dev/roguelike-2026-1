using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Resources")]
    public Seek _seekMovement;
    public Player mainPlayer;

    [Header("Value")]
    public int value = 1;

    [Header("Properties Seek")]
    public GameObject player;
    private Transform _playerPos;
    public Transform coin;
    public float maxVelocity = 5f;
    public float viewRadius = 2f;

    public void Initialized()
    {
        _seekMovement = new Seek(coin, _playerPos, maxVelocity);
    }

    void Start()
    {
        player = GameObject.Find("Player");
        _playerPos = player.GetComponent<Transform>();
        coin = GetComponent<Transform>();
        Initialized();
    }

    void Update()
    {
        Seek();
    }

    public void Seek()
    {
        float distance = Vector2.Distance(_playerPos.position, coin.position);
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
