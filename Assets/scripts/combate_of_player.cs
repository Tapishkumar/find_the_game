using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combate_of_player : MonoBehaviour
{  
    public Animator animator;
    public Transform attackpoint;
    public float attackrand = 0.5f;
    public LayerMask enemylayer;
    public Transform shield;
    public enemyscript enemyscript;
    public froggeraph froggeraph;
    public Collider2D[] hitenemy;
     

     void Start()
    {
        enemyscript = GetComponent<enemyscript>();   
    }
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
        if (Input.GetMouseButton(1))
        {
            sheildAttack();
        }
        if (Input.GetKey(KeyCode.Tab)) {
            IncreaseHealth();
        }
    }
    void Attack()
    {
        
        animator.SetTrigger("sword attack");
        
         hitenemy = Physics2D.OverlapCircleAll(attackpoint.position, attackrand, enemylayer);
        foreach (Collider2D enemy in hitenemy)
        {
            
            enemy.GetComponent<enemyscript>().Takedamage(30);
            enemy.GetComponent<frogscript>().Takedamage(50);
             
        }
        
    }
     void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        { return; }

        Gizmos.DrawWireSphere(attackpoint.position, attackrand);
        Gizmos.DrawWireSphere(shield.position, attackrand);
    }
    void sheildAttack()
    {
        animator.SetTrigger("sheild_attack");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(shield.position, attackrand, enemylayer);
        foreach (Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<enemyscript>().Takedamage(30);
          enemy.GetComponent<frogscript>().Takedamage(30);
        }
    }
    void IncreaseHealth()
    {
        animator.SetTrigger("Health_of_player");
    }
}