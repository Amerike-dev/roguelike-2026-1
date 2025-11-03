using System.Collections;
using UnityEngine;

public class WanderState : IState
{
    public EnemyBehaviour _enemy;
    public float changeTime;
    public float speed;
    
    [Header("Coordinates")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 destinationPoint;
    
    private Wander _wanderMovement;
    
    public WanderState(EnemyBehaviour enemy)
    {
        this._enemy = enemy;
        this._wanderMovement = new Wander(this._enemy.enemy, speed);
    }
    
    public void Enter()
    {
        Debug.Log("Wander State ON");
    }
    public void Update()
    {
        //enemy.enemy.position = Vector2.MoveTowards(enemy.enemy.position, destinationPoint, speed * Time.deltaTime);
        //Debug.DrawLine(enemy.enemy.position, destinationPoint, Color.red, 0f);
    }
    public void Exit()
    {
        Debug.Log("Wander State OFF");
    }

    private void GenerateNewPoint()
    {
        float pointX = Random.Range(minX, maxX);
        float pointY = Random.Range(minY, maxY);
        destinationPoint = new Vector2(pointX, pointY);
    }

    private IEnumerator DestinationPointController()
    {
        GenerateNewPoint();
        while (true)
        {
            float actualTime = 0;
            while (actualTime < changeTime)
            {
                //if (Vector2.Distance(enemy.enemy.position, destinationPoint) <= 0.1f) break;
                actualTime += Time.deltaTime;
                yield return null;
            }
            
            GenerateNewPoint();
            yield return null;
        }
    }
}
