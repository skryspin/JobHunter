using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Eraspider : NavigableEnemy
{

    public GameObject heldItem; 


    public override void Start()
    {
        contact_damage = 1; 

        if (navMeshAgent is null) {
            foreach (NavMeshAgent x in this.gameObject.GetComponentsInChildren<NavMeshAgent>()) {
                navMeshAgent = x;
            }
        }
        
        if (anim is null) {
            anim = this.gameObject.GetComponent<Animator>(); 
        }
        spawnLocation = this.gameObject.transform.position; 
        spawnRotation = this.gameObject.transform.rotation.eulerAngles;
        //Debug.Log("Script active");
    }
    
    override public void Update()
    {
        if (reachedDestination()) {
           // Debug.Log("Eraspider Reached destination."); 
        }
        setGoal(target.transform.position);
        if(dieOnNextFrame) {
            removeGoal(); 
            Destroy(this.gameObject); 
        } 
        
        heldItem.transform.position = this.gameObject.transform.position + new Vector3(0, 3.5f, 0); 

    
    }
    
    



}
