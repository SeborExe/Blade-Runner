using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/PlayerData Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("MoveState")]
    public float movementVelocity = 10f;

    [Header("JumpState")]
    public float jumpVelocity = 15f;
    public int amoutOfJumps = 1;

    [Header("InAirState")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("WallSlideState")]
    public float wallSlideVelocity = 3f;

    [Header("CheckVariables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsGround;
}
