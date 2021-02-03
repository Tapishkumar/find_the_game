using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2dscripts : MonoBehaviour
{
    public Transform target;
    public float damping = 1f;
    public float lockAheahfactor = 3f ;
    public float lookaheadreturnspeed =0.5f;
    public float lookaheadmovethreshold = 0.1f;
    public float ypositionrist = -1f;
   

    float ofsetz;
    Vector3 lasttargetpostion;
    Vector3 currentvelocity;
    Vector3 lookaheadposition;
    float nexttimetosearch =0;

    // Start is called before the first frame update
    void Start()
    {
       
        lasttargetpostion = target.position;
        ofsetz = (transform.position - target.position).z;
        transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Findplayer();
            return;
        }
        float xmovedelta = (target.position - lasttargetpostion).x;
            bool updatelookaheadtarget = Mathf.Abs(xmovedelta) > lookaheadmovethreshold;
            if (updatelookaheadtarget)
            {
                lookaheadposition = lockAheahfactor * Vector3.right * Mathf.Sign(xmovedelta);

            }
            else
            {
                lookaheadposition = Vector3.MoveTowards(lookaheadposition, Vector3.zero, Time.deltaTime * lookaheadreturnspeed);
            }
            Vector3 aheadTargetPos = target.position + lookaheadposition + Vector3.forward * ofsetz;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentvelocity, damping);


            newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, -0.5f, Mathf.Infinity), newPos.z);
            transform.position = newPos;

            lasttargetpostion = target.position;
        }

         
      
        
     


   
    public void Findplayer()
    {
        if (nexttimetosearch <= Time.time)
        {

            GameObject searchResult = GameObject.FindGameObjectWithTag ("player2");
            if (searchResult != null)
            {
                target = searchResult.transform;
                nexttimetosearch = Time.time + 0.5f;
            }
        }
    }
     
}
