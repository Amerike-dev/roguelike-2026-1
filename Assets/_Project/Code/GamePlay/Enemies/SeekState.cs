using UnityEngine;

public class SeekState : IState
{
    public Enemy enemy;
    public SeekState(Enemy enemy)
    {
        this.enemy = enemy;
    }  
    public void Enter()
    {
        Debug.Log("Seek State ON");
    }
    public void Update()
    {
        //Calculation of the Distance between the Target and the Enemy.
        float distance = Vector2.Distance(enemy.target.position, enemy.enemy.position);
        //Conditions for the changing the state.
        if(distance < enemy.viewRadius)
        {
            enemy?.Seek(); //Implementation of the Seek method.
        }
        if (distance > enemy.viewRadius)
        {
            enemy.ChangeState(new IdleState(enemy)); //Change to Idle State.
        }        
    }
    public void Exit()
    {
        Debug.Log("Seek State OFF");
    }
}
