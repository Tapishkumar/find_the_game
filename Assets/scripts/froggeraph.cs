using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class froggeraph : MonoBehaviour
{
    public Animator animator;
    public AIPath aI;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aI.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-6.264525f, 6.264525f, 6.264525f);

        }
        else if (aI.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(6.264525f, 6.264525f, 6.264525f);
        }
        
    }
}
