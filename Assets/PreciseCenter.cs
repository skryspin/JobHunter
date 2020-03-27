using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreciseCenter : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startCenter;
    
    void Start()
    {
        startCenter = this.transform.position; 
        Debug.Log(startCenter); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        ForceToCenter();
    }

    /* Forces the transform of this object to move to the exact starting position
     * This function must be called in LateUpdate to override animations
     */ 
    private void ForceToCenter() {
        this.transform.position = startCenter; 
                Debug.Log("forced to " + startCenter); 

    }
}
