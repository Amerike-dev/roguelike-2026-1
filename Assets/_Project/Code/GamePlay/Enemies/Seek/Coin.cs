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
    public Transform _playerPos;
    public Transform coin;
    public float maxVelocity = 5f;
    public float viewRadius = 5f;

    public void Initialized()
    {
        _seekMovement = new Seek(coin, _playerPos, maxVelocity);
    }

    void Start()
    {
        //player=FindObjectOfType<Player>();
        _playerPos = player.GetComponent<Transform>();
        mainPlayer=player.GetComponent<Player>();
        coin =GetComponent<Transform>();
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
            Player mainPlayer = collision.GetComponent<Player>();

            if (mainPlayer != null)
            {
                mainPlayer.AddCoin(value);
            }
            gameObject.SetActive(false);
        }
    }
}
