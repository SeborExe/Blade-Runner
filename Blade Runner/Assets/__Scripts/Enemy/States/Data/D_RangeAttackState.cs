using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangeAttackStateData", menuName = "Data/State Data/Range Attack Data")]
public class D_RangeAttackState : ScriptableObject
{
    public GameObject projectilePrefab;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance = 10f;
}
