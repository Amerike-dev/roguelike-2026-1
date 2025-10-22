using UnityEngine;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    public Transform[] patrolPoints;
    public Transform player;

    private void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState(gameObject));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(State newState)
    {
        stateMachine.ChangeState(newState);
    }
}
