using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Resources")]
    private StateMachine stateMachine;
    public Seek _seekMovement;
    public UI_G _uiG;
    public Death _death;

    [Header("Stats")]
    public float health = 10;
    public float Damage = 10;
    public string _primaryState="";

    [Header("Properties Seek")]
    public Transform target;
    public Transform enemy;
    public float maxVelocity = 5f;
    public float viewRadius = 4f;
    public string _currentStateName="";

    [Header("Properties Death")]
    public GameObject enemyGO;
    public PolygonCollider2D enemyCol;
    public float dropRange = 1.5f;
    private SpriteRenderer _spriteRenderer;

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
        _death= new Death(enemy, dropRange);
    }
    void Start()
    {
        enemyGO = this.gameObject;
        enemyCol = GetComponent<PolygonCollider2D>();
        enemy = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
    public void Drops()
    {
        _death?.OnDeath();
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


    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void Dispel()
    {
        StartCoroutine(FadeSprite());
    }
    IEnumerator FadeSprite()
    {
        enemyCol.enabled = false;
        float time = 0f;
        Color c = _spriteRenderer.color;

        while (time < 1.5f)
        {
            float t = time / 1.5f;
            _spriteRenderer.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, t));
            time += Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.color = new Color(0f, 0f, 0f, 0f);

        yield return new WaitForSeconds(2f);

        time = 0f;
        while (time < 1.5f)
        {
            float t = time / 1.5f;
            _spriteRenderer.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, t));
            time += Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.color = new Color(0f, 0f, 0f, 1f);
        enemyGO.SetActive(false);
    }
}
