using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public birdgraph birdgraph;
    public Animator animator;  
    public int Health = 1000;
    int currenthealth;
     
     void Start()
    {
        animator = GetComponent<Animator>();
        currenthealth = Health;   
    }
    public void Takedamage( int damag )
    {
         
        currenthealth -= damag;  
        if (currenthealth <= 0)
        {
            Die();
            SpriteRenderer.enabled = false;
        }
    }
    public void Die()
    {

       


        birdgraph.enabled = false;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        animator.SetBool("isdead", true);
    }

     

}
