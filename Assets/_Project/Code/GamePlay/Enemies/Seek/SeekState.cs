using UnityEngine;

public class SeekState : IState
{
    public EnemyBehaviour enemy;
    public SeekState(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }  
    public void Enter()
    {
        Debug.Log("Seek State ON");
    }
    public void Update()
    {
        float distance = Vector2.Distance(enemy.target.position, enemy.enemy.position);
        if(distance < enemy.viewRadius)
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
        Debug.Log("Seek State OFF");
    }
}
