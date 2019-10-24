using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeCollider : MonoBehaviour
{
    protected int dmg;
                


    // Start is called before the first frame update
    void Start()
    {
        dmg = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Destroy(this.gameObject.transform.parent.gameObject); 
                Destroy(this.gameObject); 
            }
        }
    }
}
