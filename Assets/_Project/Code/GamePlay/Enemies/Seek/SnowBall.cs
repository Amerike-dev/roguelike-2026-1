using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public EnemyBehaviour enemy;
    public float damage = 10;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }
    }
}
