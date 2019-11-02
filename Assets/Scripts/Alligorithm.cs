using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Alligorithm : NavigableEnemy
{

    private Collider visionCollider; 
    public BoxCollider hitbox; 
        
    // Use this for initialization
    public override void Start()
    {
        currentHealth = 3;
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
        spawnRotation = this.gameObject.transform.rotation.eulerAngles;

        //Debug.Log("Script active");

    }

    // Update is called once per frame
    public override void Update()
    {
        if(dieOnNextFrame) {
            Destroy(this.gameObject); 
        } 
        doNavigate(); 
        if (rotating) {
            Vector3 goal = spawnRotation;
            if (Vector3.Distance(transform.rotation.eulerAngles, goal) < 0.8f) {
                transform.eulerAngles = goal; 
             //   Debug.Log("Stop rotating!");
                anim.SetTrigger("StopRotating");  
            }
            else {
             //   Debug.Log("Rotating...");
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, goal, Time.deltaTime);
          
            }
        }
        
        
        
    }
    
    public void doNavigate() {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("NavigateToSpawn") && reachedDestination()) {
            removeGoal();
          //  Debug.Log("Reached destination.");
            anim.SetTrigger("ExitNavigation");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        GameObject cuddleBuddy = other.gameObject;
        //Debug.Log("Alligorithm collided with: " + cuddleBuddy);


        
        if (cuddleBuddy.GetComponent<Player>() != null)
        {
            Player player = cuddleBuddy.GetComponent<Player>(); 
            player.TakeDamage(contact_damage);
        }
    }
    
    
    
}

