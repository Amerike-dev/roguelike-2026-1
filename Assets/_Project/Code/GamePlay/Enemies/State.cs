using UnityEngine;

public abstract class State
{
    protected GameObject owner; // el objeto que usa este estado
    public State(GameObject owner)
    {
        this.owner = owner;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
