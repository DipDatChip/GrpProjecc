using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;

    public int attackDamage = 1;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetTrigger("attack");

       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemylayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return; 
         
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
