using UnityEngine;

public class IdleState : IState
{
    public EnemyBehaviour enemy;
    public IdleState(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Idle State ON");
    }
    public void Update()
    {
        float distance = Vector2.Distance(enemy.target.position, enemy.enemy.position);
        if (enemy.target == null) return;
        if (distance < enemy.viewRadius)
        {
            enemy.ChangeState(new SeekState(enemy));
        }
        if(enemy.health <= 0f)
        {
            enemy.ChangeState(new DeathState(enemy));
        }
        else
        {

        }
    }
    public void Exit()
    {
        Debug.Log("Idle State OFF");
    }
}
