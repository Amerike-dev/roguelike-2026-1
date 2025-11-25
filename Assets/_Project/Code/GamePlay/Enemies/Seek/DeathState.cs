using UnityEngine;

public class DeathState : IState
{
    public EnemyBehaviour enemy;
    public CoinDrop cDrop;
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
        cDrop?.GenerateDrops();
        

    }
    public void Exit()
    {
        Debug.Log("Death State OFF");
        Debug.Log("Reaturn Menu");
    }
}
