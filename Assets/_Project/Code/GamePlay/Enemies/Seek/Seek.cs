using UnityEngine;

public class Seek
{
    [Header("Resources")]
    private Transform _enemy;
    private Transform _target;

    [Header("Properties")]
    private float _maxVelocity = 5f;
    private Vector2 _currentVelocity;
    
    public Seek(Transform enemy,Transform target,float maxVelocity)
    {
        this._enemy = enemy;
        this._target = target;
        this._maxVelocity = maxVelocity;
    }
    public void GetSteering()
    {
        Vector2 _direction = (_target.position- _enemy.position);
        Vector2 desireVelocity = _direction * _maxVelocity;
        Vector2 steering = desireVelocity - _currentVelocity;
        steering = Vector2.ClampMagnitude(steering, _maxVelocity);
        _currentVelocity += steering * Time.deltaTime;
        _currentVelocity= Vector2.ClampMagnitude(_currentVelocity, _maxVelocity);
        _enemy.position += (Vector3)_currentVelocity *Time.deltaTime;
    }
}
