using UnityEngine;

public class DeathState : IState
{
    public EnemyBehaviour enemy;
    public CoinDrop CDrop;
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
        
    }
    public void Exit()
    {
        Debug.Log("Death State OFF");
        Debug.Log("Reaturn Menu");
    }
}
