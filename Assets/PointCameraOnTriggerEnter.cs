using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCameraOnTriggerEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Puts the Main camera in pointmode if a Player enters this object's trigger
    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled) {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null) {
                Camera.main.gameObject.GetComponent<FreeCamera>().pointmode = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (this.enabled) {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null) {
                Camera.main.gameObject.GetComponent<FreeCamera>().pointmode = false;
            }
        }

    }
}
