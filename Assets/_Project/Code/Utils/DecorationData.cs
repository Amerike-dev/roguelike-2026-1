using UnityEngine;
using System;

[Serializable]
public class DecorationData
{
    public string name;
    public int type;
    public LocationData[] locations;
}

[Serializable]
public class LocationData
{
    public int[] positions;
    public int size;
    public int type;
    public string name;
}
