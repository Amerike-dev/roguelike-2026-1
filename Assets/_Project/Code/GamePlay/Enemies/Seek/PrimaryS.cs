using UnityEngine;
using System.Collections.Generic;

public class PrimaryS
{
    public List<string> state = new List<string>() { "IdleState", "WanderState" };
    private string _randomState;
    private string _overrideState;

    public PrimaryS(string overrideState)
    {
        this._overrideState = overrideState;
    }
    public void SetState()
    {
        string randomState = RandomState();
        string overrideState = randomState;
        Debug.Log(overrideState);

    }
    public string RandomState()
    {
        if (state.Count == 0)
        {
            return string.Empty;
        }
        int index= Random.Range(0, state.Count);
        return state[index];
    }


}
