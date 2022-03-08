using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/PlayerData Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("MoveState")]
    public float movementVelocity = 10f;
}
