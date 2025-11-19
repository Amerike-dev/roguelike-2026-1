using UnityEngine;
using System;

[Serializable]
//Relacionado a la generacion del Dungeon
public class EnemyData
{
    public int wave;
    public int[] position;
    public int enemyType;
}

[Serializable]
public class ListEnemyData
{
    public Enemy[] enemies;
}

[Serializable]
public class Enemy
{
    public string name;
    public int id;
    public int asset;
    public int attack;
}