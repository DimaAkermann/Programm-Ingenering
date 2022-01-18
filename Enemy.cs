using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    
   
}
