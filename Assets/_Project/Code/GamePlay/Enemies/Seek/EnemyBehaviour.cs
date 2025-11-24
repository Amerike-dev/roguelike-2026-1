using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Resources")]
    private StateMachine stateMachine;
    public Seek _seekMovement;
    public Death _Death;

    [Header("Stats")]
    public float health;
    public string _primaryState="";

    [Header("Properties Seek")]
    public Transform target;
    public Transform enemy;
    public float maxVelocity = 5f;
    public float viewRadius = 4f;
    public string _currentStateName="";

    [Header("Properties Death")]
    public GameObject enemyGO;
    public SpriteRenderer spriteR;

    [Header("Properties Wander")]
    public float distX;
    public float distY;
    public float changeTime;
    public Vector2 targetPoint;
    public float circleDistance;
    public Vector2 circleOrigin;
    public GameObject circle;
    public float circleRadius;
    public Vector2 displacement;
    public float wanderAngle;
    public float changeAngle;

    public void Initialized()
    {
        _seekMovement = new Seek(enemy, target, maxVelocity);
        _Death = new Death(enemyGO, spriteR);
    }
    void Start()
    {
        enemyGO = this.gameObject;
        enemy = GetComponent<Transform>();
        spriteR = GetComponent<SpriteRenderer>();
        Initialized();
        stateMachine = new StateMachine();
        ChangeState(new IdleState(this));
    }
    void Update()
    {
        stateMachine.Update();
        _currentStateName = stateMachine.CurrentState != null ? stateMachine.CurrentState.GetType().Name : "Sin Estado";
    }
    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }
    public void Seek()
    {
        _seekMovement?.GetSteering();
    }
    public void EnterWander()
    {
        StartCoroutine(GenerateRandomTargets());
        StartCoroutine(GenerateRandomAngles());
    }
    public void ExitWander()
    {
        StopCoroutine(GenerateRandomTargets());
        StopCoroutine(GenerateRandomAngles());
    }

    public IEnumerator GenerateRandomTargets()
    {
        while (true)
        {
            float x = Random.Range(-distX, distX);
            float y = Random.Range(-distY, distY);
            targetPoint = new Vector2(x, y);
            yield return new WaitForSeconds(changeTime);
        }
    }

    public IEnumerator GenerateRandomAngles()
    {
        while (true)
        {
            wanderAngle = Random.Range(0, 360f);
            yield return new WaitForSeconds(changeAngle);
        }
    }
}
