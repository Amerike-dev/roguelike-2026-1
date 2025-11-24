using UnityEngine;
using System.Collections;

public class Death
{
    private GameObject _enemy;
    private float _health;

    public Death(GameObject enemy,float health)
    {
        this._enemy = enemy;
        this._health = health;
    }

}
