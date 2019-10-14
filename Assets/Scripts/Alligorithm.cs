using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Alligorithm : NavigableEnemy
{

    private Collider visionCollider; 
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
        spawnRotation = this.gameObject.transform.rotation.eulerAngles;

        //Debug.Log("Script active");

    }

    // Update is called once per frame
    public override void Update()
    {
        doNavigate(); 
        if (rotating) {
            Vector3 goal = spawnRotation;
            if (Vector3.Distance(transform.rotation.eulerAngles, goal) < 0.01f) {
                transform.eulerAngles = goal; 
                rotating = false; 
            }
            else {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, goal, Time.deltaTime);
          
            }
        }
        
    }
    
    public void doNavigate() {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("NavigateToSpawn") && reachedDestination() && !rotating) {
            removeGoal();
            Debug.Log("Reached destination.");
            anim.SetTrigger("ExitNavigation");
        }
    } 
    
    public override void sawPlayer(Vector3 position) {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Charge")) { //don't try to charge if already charging!
            anim.SetTrigger("SawPlayer");
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

