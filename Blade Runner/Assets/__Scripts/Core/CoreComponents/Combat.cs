using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamagable, IKnockbackable
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }
    private Stats Stats { get => stats ?? core.GetCoreComponent(ref stats); }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Stats stats;

    [SerializeField] private float maxKnockbackTtime = 0.2f;

    private bool isKnockbackActive;
    private float knockbackStartTime;

    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " Damaged");
        Stats?.DecreaseHealth(amount);
    }

    public void Knockback(Vector2 angle, float strenght, int direction)
    {
        Movement?.SetVelocity(strenght, angle, direction);
        Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (isKnockbackActive && ((Movement.currentVelocity.y <= 0.01f && CollisionSenses.Ground) || Time.time >= knockbackStartTime + maxKnockbackTtime))
        {
            isKnockbackActive = false;
            Movement.CanSetVelocity = true;
        }
    }
}
