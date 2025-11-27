using UnityEngine;
using System.Collections;

public class Death
{
    public Transform enemyT;
    public float dispersion = 1.5f;
    public bool dropSP;
    public Death(Transform enemyT, float dispersion)
    {
        this.enemyT = enemyT;
        this.dispersion = dispersion;
    }
    public void OnDeath()
    {
        if (!dropSP)
        {
            DropGen();
        }
    }
    public void DropGen()
    { 
        dropSP = true;
        int amount = Random.Range(2, 21);
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Poolmanager.Instance.GetFromPool();
            obj.transform.position = enemyT.position + (Vector3)Random.insideUnitCircle * dispersion;
        }
    }
}
