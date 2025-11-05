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
        Vector2 currentPos = enemy.transform.position;
        Vector2 target = enemy.targetPoint;
        
        Debug.DrawLine(currentPos, target, Color.red);
        
        enemy.transform.position = Vector2.MoveTowards(currentPos, target, enemy.maxVelocity * Time.deltaTime);
        
        float distance = Vector2.Distance(currentPos, target);
        if (distance < 0.1f) return;
        
        float playerDistance = Vector2.Distance(enemy.target.position, enemy.transform.position);
        if (playerDistance < enemy.viewRadius) enemy.ChangeState(new SeekState(enemy));
    }
    
    public void Exit()
    {
        enemy.ExitWander();
    }
}
