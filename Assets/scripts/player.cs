using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{ 
    [System.Serializable]
    public class playerstats
    {
        public int health = 100; 

    }
    public playerstats Playerstats = new playerstats();
    public int fallyboundry = -20; 
     void Update()
    {
        if (transform.position.y <= fallyboundry)
            Damageplayer(99999);
        
    }
    public  void Damageplayer(int damage)
    {
        Playerstats.health -= damage;
        if (Playerstats.health <= 0 )
        {
            gamemaster.Killplayer(this);
        }
    }

    

}
