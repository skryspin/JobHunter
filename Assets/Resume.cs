using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    protected Vector3 direction =  new Vector3(0, 0, 0);
    public float div;  
    // Start is called before the first frame update
    void Start()
    { 
        div = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Position: " + this.transform.position);
        Debug.Log(this.direction); 
        Debug.Log(div);
        Debug.Log("x, y, z,: " + (direction.x / div) + (direction.y / div) +  (direction.z / div));
        this.transform.position += new Vector3(direction.x / div, direction.y / div, direction.z / div); 
    }
    
    public void SetDirection(Vector3 dir) {
        direction = Vector3.Normalize(dir);
    }
}
