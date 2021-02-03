using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaster : MonoBehaviour
{
    public static gamemaster Gm;
     void Start()
    {
        Gm = GetComponent<gamemaster>();
        if (Gm == null)
        {

            Gm = GameObject.FindGameObjectWithTag("gm").GetComponent<gamemaster>();
        }
        
    }
    public Transform transformprefeb;
    public Transform spawnpoint;
    
    public void respownplayer()
    {
        Instantiate(transformprefeb, spawnpoint.position, spawnpoint.rotation);
        Debug.Log("to do");

    }
    public  static void Killplayer(player player)
    {
        Destroy(player.gameObject);
        Gm.respownplayer();
    }

     
}
