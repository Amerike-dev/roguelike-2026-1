using UnityEngine;

public class ChaseState : State
{
    private Transform player;
    private float speed = 3.5f;

    public ChaseState(GameObject owner) : base(owner)
    {
        player = owner.GetComponent<Enemy>().player;
    }

    public override void Enter()
    {
        Debug.Log("Entrando a Persecución");
    }

    public override void Update()
    {
        owner.transform.position = Vector2.MoveTowards(
            owner.transform.position,
            player.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(owner.transform.position, player.position) > 7f)
        {
            owner.GetComponent<Enemy>().ChangeState(new IdleState(owner));
        }
    }

    public override void Exit()
    {
        Debug.Log("Saliendo de Persecución");
    }
}
