using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public abstract class NavigableEnemy : SightedEnemy
{
    private GameObject currentDestinationMarker; 
    public GameObject destinationMarkerPrefab; 
    protected NavMeshAgent navMeshAgent; 
    protected Vector3 goal; 
    public bool rotating = false; 
    protected int buffer = 0;


    // Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}{
    
    public void removeGoal() {
        Destroy(currentDestinationMarker);
        navMeshAgent.ResetPath();
    }
    
    public void setGoal(Vector3 goal) {
        if (currentDestinationMarker != null) 
            Destroy(currentDestinationMarker);
        this.goal = goal;
        navMeshAgent.destination = goal; 
        currentDestinationMarker = Instantiate(destinationMarkerPrefab, goal, Quaternion.identity);
        buffer = 120; 
    }
    
    /* from https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html */
    public bool reachedDestination() {
        if (!navMeshAgent.pathPending) {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
                if (navMeshAgent.velocity.sqrMagnitude == 0f) {
                    return true; 
                }
            }
        }
        return false;
    }
    
}
