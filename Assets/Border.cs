using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void enableBorders() {
        foreach (BoxCollider x in this.transform.GetComponents<BoxCollider>()) {
            x.enabled = true; 
        }
    }
    
    public void disableBorders() {
        foreach (BoxCollider x in this.transform.GetComponents<BoxCollider>()) {
            x.enabled = false; 
        }
    }
}
