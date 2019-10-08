using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Alligorithm2 : NavigableEnemy
{

    private Collider visionCollider; 
    //private NavMeshAgent navMeshAgent; 
    private Animator anim;

    
    
    
    // Use this for initialization
    public override void Start()
    {
        currentHealth = 1;
        maxHealth = 1; 
        contact_damage = 1; 
        if (visionCollider is null) {
            foreach (Collider x in this.gameObject.GetComponentsInChildren<Collider>()) {
                if (x.gameObject.name == "VisionCollider") {
                    visionCollider = x; 
                }
             
            } 
        
        }
        if (navMeshAgent is null) {
            foreach (NavMeshAgent x in this.gameObject.GetComponentsInChildren<NavMeshAgent>()) {
                navMeshAgent = x;
            }
        }
        
        if (anim is null) {
            anim = this.gameObject.GetComponent<Animator>(); 
        }
        
        spawnLocation = this.gameObject.transform.position; 
        Debug.Log("Script active");

    }

    // Update is called once per frame
    public override void Update()
    {
        if (goal != null && buffer > 0) {
            navMeshAgent.destination = goal; 
            buffer--;
        }
    }
    
    //public override void setGoal(Vector3 goal) {
        //if (currentDestinationMarker != null) 
        //    Destroy(currentDestinationMarker);
        //this.goal = goal;
        //currentDestinationMarker = Instantiate(destinationMarkerPrefab, goal, Quaternion.identity);
        //buffer = 120; 
    //}

    public override void sawPlayer(Vector3 goal)
    {
        //do nothing
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject cuddleBuddy = other.gameObject;
        //Debug.Log("Alligorithm collided with: " + cuddleBuddy);
        
        if (cuddleBuddy.GetComponent<Player>() != null)
        {
            Debug.Log("setting goal..."); 
            Player player = cuddleBuddy.GetComponent<Player>(); 
            //player.TakeDamage(contact_damage);
            setGoal(player.transform.position);
        }
    }
    
}

