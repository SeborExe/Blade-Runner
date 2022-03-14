using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamagable, IKnockbackable
{
    private bool isKnockbackActive;
    private float knockbackStartTime;

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " Damaged");
    }

    public void Knockback(Vector2 angle, float strenght, int direction)
    {
        core.Movement.SetVelocity(strenght, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (isKnockbackActive && core.Movement.currentVelocity.y <= 0.01f && core.CollisionSenses.Ground)
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }
}
