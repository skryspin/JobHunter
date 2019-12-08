using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class TriggerNavigation : MonoBehaviour
{
    public GameObject toEnable; //the object to enable
    
    void Start()
    {
        Collider trigger = this.gameObject.GetComponent<Collider>(); // Make sure there is a collider attached
        if (trigger == null) {
            Debug.LogError("There is no trigger attached to this gameobject."); 
        }
        if (toEnable == null) {
            Debug.LogError("toEnable is null"); 
        }
        if (!trigger.isTrigger) {
            Debug.LogError("Error: trigger collider is not marked \"is Trigger\"."); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/* 
 * Enables toEnable's NavMeshAgent if triggered by player. 
 */ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) { //only trigger enemy if its the player!
            if (toEnable != null) {
                toEnable.gameObject.GetComponent<NavMeshAgent>().enabled = true; 
            }
        }
    }
}
