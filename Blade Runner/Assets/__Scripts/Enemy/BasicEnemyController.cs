using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    private State currentState;

    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;

            case State.Knockback:
                UpdateKnockbackState();
                break;

            case State.Dead:
                UpdateDeadState();
                break;
        }
    }

    //-----------Walkig state---------------------------------------------------------------------//
    private void EnterWalkingState()
    {

    }

    private void UpdateWalkingState()
    {

    }

    private void ExitWalkingState()
    {

    }

    //-----------Knockback state---------------------------------------------------------------------//
    private void EnterKnockbackState()
    {

    }

    private void UpdateKnockbackState()
    {

    }

    private void ExitKnockbackState()
    {

    }

    //-----------Dead state---------------------------------------------------------------------//
    private void EnterDeadState()
    {

    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }

    //----Other functions -----------------------------------------------------//

    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;

            case State.Knockback:
                ExitKnockbackState();
                break;

            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Walking:
                EnterWalkingState();
                break;

            case State.Knockback:
                EnterKnockbackState();
                break;

            case State.Dead:
                EnterDeadState();
                break;
        }

        currentState = state;
    }
}
