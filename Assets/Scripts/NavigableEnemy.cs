using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public abstract class NavigableEnemy : Enemy
{
    private GameObject currentDestinationMarker; 
    public GameObject destinationMarkerPrefab; 
    public NavMeshAgent navMeshAgent; 
    public GameObject target; 
    protected Vector3 goal; 
    public bool rotating = false; 
    public bool displayDestination; //display destination marker or not


    // Use this for initialization
    override public void Start()
    {
        base.Start(); 
        contact_damage = 1; 

    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update(); 
    }
    
    public void removeGoal() {
        Destroy(currentDestinationMarker);
        navMeshAgent.ResetPath();
    }
    
    public void setGoal(Vector3 goal) {
        if (currentDestinationMarker != null) 
            Destroy(currentDestinationMarker);
        this.goal = goal;
        
        if (navMeshAgent.isOnNavMesh) {
            navMeshAgent.destination = goal; 
        }
        if (displayDestination) {
            currentDestinationMarker = Instantiate(destinationMarkerPrefab, goal, Quaternion.identity);
        }
    }
    
    /* adapted from https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html */
    public bool reachedDestination() {
        if (!navMeshAgent.pathPending && navMeshAgent.hasPath) {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
                Debug.Log("removing goal");
                removeGoal();
                //if (navMeshAgent.velocity.sqrMagnitude == 0f) {
                    return true; 
                //}
            }
        }
        return false;
    }
    
}
