using System.Collections;
using UnityEngine;

public class WanderState : IState
{
    public EnemyBehaviour enemy;
    public WanderState(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        enemy.EnterWander();
    }
    public void Update()
    {
        float distance = Vector2.Distance(enemy.target.position, enemy.enemy.position);
        if (distance < enemy.viewRadius)
        {
            enemy?.Seek();
        }
        if (distance > enemy.viewRadius)
        {
            enemy.ChangeState(new IdleState(enemy));
        }
    }
    public void Exit()
    {
        enemy.ExitWander();
    }
}
