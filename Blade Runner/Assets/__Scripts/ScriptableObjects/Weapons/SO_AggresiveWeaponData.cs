using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewAggresiveWeaponData", menuName = "Data/Weapon Data/Aggresive Weapon")]
public class SO_AggresiveWeaponData : SO_WeaponData
{
    [SerializeField]
    private WeaponAttackDetails[] attackDetails;

    public WeaponAttackDetails[] AttackDetails { get => attackDetails; private set => attackDetails = value; }

    private void OnEnable()
    {
        amoutOfAttacks = attackDetails.Length;

        movementSpeed = new float[amoutOfAttacks];

        for (int i=0; i<amoutOfAttacks; i++)
        {
            movementSpeed[i] = attackDetails[i].movementSpeed;
        }
    }
}
