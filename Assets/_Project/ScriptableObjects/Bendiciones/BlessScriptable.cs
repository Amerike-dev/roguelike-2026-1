using UnityEngine;

[CreateAssetMenu(fileName = "BlessScriptable", menuName = "Scriptable Objects/BlessScriptable")]
public class BlessScriptable : ScriptableObject
{
    public string name;
    public string description;
    public TypeBlessing type;
    public float value;
}
