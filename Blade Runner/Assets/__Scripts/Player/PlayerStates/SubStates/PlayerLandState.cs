using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xinput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (isAnimationFinish)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
