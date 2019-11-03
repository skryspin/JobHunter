﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Eraspider : NavigableEnemy
{

    public Pickup heldItem; 
    


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
        if (navMeshAgent.enabled) {
            if (reachedDestination()) {
               // Debug.Log("Eraspider Reached destination."); 
            }
            setGoal(target.transform.position);
        }
        if(dieOnNextFrame) {
            removeGoal(); 
            Destroy(this.gameObject); 
        } 
        
        if (heldItem != null) {
            heldItem.isHeld = true; 
            heldItem.transform.position = this.gameObject.transform.position + new Vector3(0, 3.5f, 0); 
        }

    
    }
    
    
    override public void takeDamage(int x) {
        base.takeDamage(x);
        
        if (heldItem != null) {
            dropPickup();
        }
    }
    
    public void dropPickup() {
        heldItem.GetComponent<SphereCollider>().enabled = true; 
        heldItem.GetComponent<BoxCollider>().isTrigger = false;
        heldItem.isHeld = false;  
        heldItem = null;
        
    }
    
    



}