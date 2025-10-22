using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = newState;

        if (CurrentState != null)
            CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
            CurrentState.Update();
    }
}
