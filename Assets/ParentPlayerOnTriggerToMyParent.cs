using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayerOnTriggerToMyParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null) {
            player.transform.parent = this.transform.parent;
        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null) {
            player.transform.parent = null;
        }
    }        
}
