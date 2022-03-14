using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggresiveWeapon : Weapon
{
    protected SO_AggresiveWeaponData aggresiveWeaponData;

    private List<IDamagable> detectedDamagable = new List<IDamagable>();

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(SO_AggresiveWeaponData))
        {
            aggresiveWeaponData = (SO_AggresiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggresiveWeaponData.AttackDetails[attackCounter];

        foreach (IDamagable item in detectedDamagable.ToList())
        {
            item.Damage(details.damageAmount);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamagable damageable = collision.GetComponent<IDamagable>();

        if (damageable != null)
        {
            detectedDamagable.Add(damageable);
        }
    }
    
    public void RemoveFromDetected(Collider2D collision)
    {
        IDamagable damageable = collision.GetComponent<IDamagable>();

        if (damageable != null)
        {
            detectedDamagable.Remove(damageable);
        }
    }
}
