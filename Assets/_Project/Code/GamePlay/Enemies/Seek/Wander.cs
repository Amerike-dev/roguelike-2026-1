using UnityEngine;

public class Wander
{
    [Header("Resources")]
    private Transform _enemy;
    private Vector2 _destinationPoint;

    private float _speed;

    public Wander(Transform enemy, float speed)
    {
        _enemy = enemy;
        _speed = speed;
    }

    public void MoveToPoint(Vector2 destination)
    {
        _destinationPoint = destination;
        _enemy.position = Vector2.MoveTowards(_enemy.position, _destinationPoint, _speed * Time.deltaTime);
    }
}
