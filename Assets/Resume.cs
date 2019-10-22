using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    protected Vector3 direction =  new Vector3(0, 0, 0);
    public float div;  
    protected int dmg;
    // Start is called before the first frame update
    void Start()
    { 
        div = 5;
        dmg = 1;
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("Position: " + this.transform.position);
      //  Debug.Log(this.direction); 
      //  Debug.Log(div);
      //  Debug.Log("x, y, z,: " + (direction.x / div) + (direction.y / div) +  (direction.z / div));
        this.transform.position += new Vector3(direction.x / div, direction.y / div, direction.z / div); 
        transform.rotation = Quaternion.LookRotation(direction); 
        Debug.Log("Resume direction: " + direction); 
        Vector3 forward=  Quaternion.AngleAxis(90, Vector3.up) * direction;
        Debug.Log("Desired direction of forward: " + forward); 
        transform.rotation = Quaternion.LookRotation(forward); 
        Debug.Log("New forward: " + transform.forward); 
         Debug.Log("forward: " + transform.forward); 


    }
    
    public void SetDirection(Vector3 dir, Transform transform) {
        direction = Vector3.Normalize(dir);
        Debug.DrawRay(this.transform.position, direction, Color.red); 
        Debug.Log("Resume direction: " + direction); 
        Vector3 forward=  Quaternion.AngleAxis(90, Vector3.up) * direction;
        Debug.Log("Desired direction of forward: " + forward); 
        transform.rotation = Quaternion.LookRotation(forward); 
        Debug.Log("New forward: " + transform.forward); 
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        ResumeHitbox temp = other.gameObject.GetComponent<ResumeHitbox>();
        if (temp != null) {
            Debug.Log("A resume hitbox was hit!"); 
            Enemy temp2 = temp.parent.GetComponent<Enemy>();
            if (temp != null) {
                Debug.Log("An enemy IS IN this resume's TRIGGER!"); 
                temp2.takeDamage(dmg);
            }
        }
    }
}
