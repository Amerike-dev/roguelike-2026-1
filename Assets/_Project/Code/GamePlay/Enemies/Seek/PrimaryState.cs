using UnityEngine;

public class PrimaryState : IState
{
    public EnemyBehaviour enemy;
    public PrimaryState(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Start Random PrimaryState");
    }
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
