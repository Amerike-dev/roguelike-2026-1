using UnityEngine;

public class IdleState : State
{
    private float idleTime;
    private float timer;

    public IdleState(GameObject owner, float idleTime = 2f) : base(owner)
    {
        this.idleTime = idleTime;
    }

    public override void Enter()
    {
        timer = 0;
        Debug.Log("Entrando a estado: Idle");
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            // Cambia al estado de patrulla
            owner.GetComponent<Enemy>().ChangeState(new PatrolState(owner));
        }
    }

    public override void Exit()
    {
        Debug.Log("Saliendo de Idle");
    }
}
