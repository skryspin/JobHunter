using UnityEngine;
using System.Collections;

public abstract class SightedEnemy : Enemy
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    abstract public void setGoal(Vector3 goal);
}
