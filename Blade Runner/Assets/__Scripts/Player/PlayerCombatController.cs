using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    private bool gotInput, isAttacking, isFirstAttack;

    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    private float lastInputTime = Mathf.NegativeInfinity;

    [SerializeField]
    private float stunDamageAmount = 1f;

    private AttackDetails attackDetails;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private LayerMask whatIsDamageable;

    private Animator anim;
    private PlayerController PC;
    private PlayerStats PS;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<PlayerController>();
        PS = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;

                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
            }
        }

        if (Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable); //point, radius, layerMask

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach (Collider2D collider in detectedObject)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);

            //Instantate hit particle

        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }

    private void Damage(AttackDetails attackDetails)
    {
        if (!PC.GetDashStatus())
        {
            int direction;

            PS.DecreaseHealth(attackDetails.damageAmount);  

            if (attackDetails.position.x < transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            PC.Knockback(direction);
        }
    }

    private void OnDrawGizmos()
    {
        //Draw hitbox
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
}
