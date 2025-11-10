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
        
        float distance = Vector2.Distance(currentPos, target);
        if (distance < 0.1f) return;
        
        float playerDistance = Vector2.Distance(enemy.target.position, enemy.transform.position);
        if (playerDistance < enemy.viewRadius) enemy.ChangeState(new SeekState(enemy));

        enemy.circleOrigin = (target - currentPos).normalized * enemy.circleDistance;
        Debug.DrawLine(currentPos, enemy.circleOrigin + currentPos, Color.blue);
        enemy.circle.transform.position = enemy.circleOrigin + currentPos;
        enemy.circle.transform.localScale = new Vector2(enemy.circleRadius, enemy.circleRadius);
        
        Quaternion rotate = Quaternion.AngleAxis(enemy.wanderAngle, Vector3.forward);
        enemy.displacement = rotate * (target - currentPos).normalized * (enemy.circleRadius / 2);
        Vector2 endPoint = (enemy.circleOrigin + currentPos) + enemy.displacement;
        Debug.DrawLine(enemy.circleOrigin + currentPos, endPoint, Color.green);
        Debug.DrawLine(currentPos, endPoint, Color.yellow);
        
        enemy.transform.position = Vector2.MoveTowards(currentPos, endPoint, enemy.maxVelocity * Time.deltaTime);
    }
    
    public void Exit()
    {
        enemy.ExitWander();
    }
}
