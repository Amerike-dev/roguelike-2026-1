using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Resources")]
    private StateMachine stateMachine;
    public Seek _seekMovement;

    [Header("Properties")]
    public Transform target;
    public Transform enemy;
    public float maxVelocity = 5f;
    public float viewRadius = 4f;
    public string _currentStateName="";

    public void Initialized()
    {
        _seekMovement = new Seek(enemy, target, maxVelocity);
    }
    void Start()
    {
        enemy = GetComponent<Transform>();
        Initialized();
        stateMachine = new StateMachine();
        ChangeState(new IdleState(this));
    }
    void Update()
    {
        stateMachine.Update();
        _currentStateName = stateMachine.CurrentState != null ? stateMachine.CurrentState.GetType().Name : "Sin Estado";
    }
    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }
    public void Seek()
    {
        _seekMovement?.GetSteering();
    }
}
