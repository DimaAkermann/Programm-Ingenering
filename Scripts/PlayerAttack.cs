using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public float health;
    public int damage;
    public Animator animator;
    bool isAttacking = false;

    private void Update()
    {
       if(Input.GetButtonDown("Fire1") && !isAttacking)
        {
            int choose = UnityEngine.Random.Range(1, 4);
            animator.Play("Player_Attack" + choose);

            Invoke("ResetAttack", .5f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void ResetAttack()
    {
        isAttacking = false;
    }
}
