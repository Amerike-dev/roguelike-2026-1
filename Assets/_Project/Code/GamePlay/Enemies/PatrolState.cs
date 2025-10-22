using UnityEngine;

public class PatrolState : State
{
    private Transform[] points;
    private int currentIndex = 0;
    private float speed = 2f;

    public PatrolState(GameObject owner) : base(owner)
    {
        points = owner.GetComponent<Enemy>().patrolPoints;
    }

    public override void Enter()
    {
        Debug.Log("Entrando a Patrulla");
    }

    public override void Update()
    {
        if (points.Length == 0) return;

        Transform target = points[currentIndex];
        owner.transform.position = Vector2.MoveTowards(
            owner.transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(owner.transform.position, target.position) < 0.2f)
        {
            currentIndex = (currentIndex + 1) % points.Length;
        }

        // Ejemplo de transición
        if (Vector2.Distance(owner.transform.position, owner.GetComponent<Enemy>().player.position) < 5f)
        {
            owner.GetComponent<Enemy>().ChangeState(new ChaseState(owner));
        }
    }

    public override void Exit()
    {
        Debug.Log("Saliendo de Patrulla");
    }
}
