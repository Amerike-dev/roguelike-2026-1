using UnityEngine;

public class DeathState : IState
{
    public EnemyBehaviour enemy;
    public DeathState(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Death State ON");
    }
    public void Update()
    {
        enemy?.Dispel();
        enemy?.Drops();
    }
    public void Exit()
    {
        Debug.Log("Death State OFF");
    }
}
