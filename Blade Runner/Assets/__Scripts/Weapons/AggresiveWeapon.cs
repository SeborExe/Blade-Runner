using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveWeapon : Weapon
{
    private List<IDamagable> detectedDamagable = new List<IDamagable>();

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
    }
}
