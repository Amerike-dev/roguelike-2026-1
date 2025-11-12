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
        Debug.Log("Seek State ON");
    }
    public void Update()
    {

    }
    public void Exit()
    {
        Debug.Log("Seek State OFF");
    }
}
