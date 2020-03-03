using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class SecurityGuard : NavigableEnemy
{
    public Transform[] patrolPoints; 
    private int patrolIndex = 0; //the index we are at in the patrolIndex array
    // Use this for initialization
    public override void Start()
    {
        try {
            patrolPoints[1].ToString(); 
            patrolPoints[0].ToString(); 
        } catch {
            Debug.LogError("SecurityGuard must have at least 2 patrol points");
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update(); 
    }

    public override void takeDamage(int x)
    {
        base.takeDamage(x);
        this.anim.SetTrigger("SawPlayer");
    }
    
    /* Checks if the SecurityGuarde has reached its patrol target.
     * If so, updates the patrol target */ 
    public void patrol() {
   
        if (reachedDestination() || !navMeshAgent.hasPath) {
            swapPatrolTarget();
        }
        else {
            setGoal(patrolPoints[patrolIndex].position);
        }
    }
    
    /* Updates the SecurityGuard's navigation target to be the next 
     * patrolPoint in circular sequence */
    private void swapPatrolTarget() {
        if (patrolIndex + 1 >= patrolPoints.Length) {
            patrolIndex = 0;
        }
        else {
            patrolIndex++;
        }
        setGoal(patrolPoints[patrolIndex].position); 
    }
    
}
