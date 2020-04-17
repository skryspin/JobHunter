using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    protected Vector3 direction =  new Vector3(0, 0, 0);
    public float div;  
    
    // Start is called before the first frame update
    protected virtual void Start()
    { 
        div = 3;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        this.transform.position += new Vector3(direction.x / div, direction.y / div, direction.z / div); 
        transform.rotation = Quaternion.LookRotation(direction); 
        Vector3 forward=  Quaternion.AngleAxis(90, Vector3.up) * direction;
        transform.rotation = Quaternion.LookRotation(forward); 
    }
    
    public virtual void SetDirection(Vector3 dir) {
        direction = Vector3.Normalize(dir);
        Debug.DrawRay(this.transform.position, direction, Color.red); 
        Vector3 forward=  Quaternion.AngleAxis(90, Vector3.up) * direction;
        this.GetComponentInChildren<MeshRenderer>(true).enabled = true; //re-enabled mesh renderer  
    }
}
