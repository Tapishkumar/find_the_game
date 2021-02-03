using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogscript : MonoBehaviour
{  
    public SpriteRenderer SpriteRenderer;
    public  froggeraph froggeraph;
    public Animator animator;  
    public int Health = 2000;
    int currenthealth;
    public gamemaster gamemaster;
     
     void Start()
    {
       
        animator = GetComponent<Animator>();
        currenthealth = Health;   
    }
    public void Takedamage( int damag1 )
    {
        currenthealth -= damag1;
        if (currenthealth <= 0)
        {
            Die();
            SpriteRenderer.enabled = false;
        }
    }
    public void Die()
    {
 
        froggeraph.enabled = false;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
         
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("player2"))  
        {

            Destroy(collision.gameObject );

            
           
        }
        
    }

}
