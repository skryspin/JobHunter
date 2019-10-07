using UnityEngine;
using System.Collections;

public abstract class NavigableEnemy : SightedEnemy
{
    private GameObject currentDestinationMarker; 
    public GameObject destinationMarkerPrefab; 
    protected Vector3 goal; 
    protected int buffer = 0;


    // Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    
    public void setGoal(Vector3 goal) {
        if (currentDestinationMarker != null) 
            Destroy(currentDestinationMarker);
        this.goal = goal;
        currentDestinationMarker = Instantiate(destinationMarkerPrefab, goal, Quaternion.identity);
        buffer = 120; 
    }
}
