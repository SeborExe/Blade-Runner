using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPos;
    private Vector2 cornerPosition;
    private Vector2 startPos;
    private Vector2 stopPos;

    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();
        player.transform.position = detectedPos;
        cornerPosition = player.DeterminCornerPosition();

        startPos.Set(cornerPosition.x - (player.FacingDirection * playerData.startOffset.x), cornerPosition.y - playerData.startOffset.y);
        stopPos.Set(cornerPosition.x + (player.FacingDirection * playerData.stopOffset.x), cornerPosition.y + playerData.stopOffset.y);

        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityZero();
        player.transform.position = startPos;
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;
}
