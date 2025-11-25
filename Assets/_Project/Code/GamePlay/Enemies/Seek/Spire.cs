using UnityEngine;

public class Spire : MonoBehaviour
{
    public PlayerController mainPlayer;
    public float damage = 10;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController mainPlayer = collision.GetComponent<PlayerController>();

            if (mainPlayer != null)
            {
                mainPlayer.TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }
    }
}
