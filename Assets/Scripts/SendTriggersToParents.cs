using UnityEngine;
using System.Collections;

public class SendTriggersToParents : MonoBehaviour
{
    private Enemy parent;
 
    void Start()
    {
        parent = transform.parent.gameObject.transform.parent.GetComponent<Enemy>();
    }
     
    void OnTriggerEnter(Collider other)
    {
        parent.OnTriggerEnter(other); // trigger the parent's collider
      //  Debug.Log("On trigger enter..."); 
    }
    
    void OnTriggerStay(Collider other)
    {
         parent.OnTriggerStay(other); // trigger the parent's collider
      //   Debug.Log("On trigger Stay..."); 

    }
    
    void OnTriggerExit(Collider other)
    {
        parent.OnTriggerExit(other); // trigger the parent's collider
     //  Debug.Log("On trigger Exit..."); 

    }
}
