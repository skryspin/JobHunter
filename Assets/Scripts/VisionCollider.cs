using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCollider : MonoBehaviour
{
    public Enemy body; // the body that owns this vision collider 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   private void OnTriggerStay(Collider other)
    {
        GameObject cuddleBuddy = other.gameObject;
        //Debug.Log(body.name + " saw " + cuddleBuddy + "!");


        if (cuddleBuddy.GetComponent<Player>() != null)
        {
            Player player = cuddleBuddy.GetComponent<Player>(); 
            Debug.Log("VisionCollider found player"); 
            Debug.Log(player);
            Debug.Log(player.transform.position);
            if (!body.anim.GetCurrentAnimatorStateInfo(0).IsName("Charge")) //don't try to charge if already charging!
                body.anim.SetTrigger("SawPlayer"); 
            
        }
    }
}
