using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Seek _seekMovement;

    public Transform target;
    private Transform enemy;
    public float maxVelocity = 5f;
    public float velocity = 2f;
    public void Initialized()
    {
        _seekMovement = new Seek(enemy, target, maxVelocity, velocity);
    }
    void Start()
    {
        enemy = GetComponent<Transform>();
        Initialized();
    }

    void Update()
    {
        _seekMovement?.GetSteering();
    }
}
