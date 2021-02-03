using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class birdgraph : MonoBehaviour
{
     
    public AIPath aI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aI.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-3.6167f, 3.6167f, 3.6167f);

        }
        else if (aI.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(3.6167f, 3.6167f, 3.6167f);
        }
    }
}
