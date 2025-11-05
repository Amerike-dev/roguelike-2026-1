using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class MapData
{
    public string type;
    public int[] size;
    public EnemyData[] enemies;
    public DecorationData[] decorations;
}
