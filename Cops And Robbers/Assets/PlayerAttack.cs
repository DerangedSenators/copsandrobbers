using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius = 0.5f;
    public LayerMask enemyLayer;
    public float dmg = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        foreach (Collider2D enemy in enemiesHit)
        {
            enemy.GetComponent<Enemy>().TakeDamage(dmg);
            //Debug.Log("attaced an enemy");
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint.position == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
