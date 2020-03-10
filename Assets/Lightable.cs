using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightable : MonoBehaviour
{
    public Light unlit;
    public Light lit; 
    // Start is called before the first frame update
    void Start()
    {
        unlit.enabled = true; 
        lit.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other.gameObject); 
        if (this.lit.enabled == false) {
            if (other.gameObject.name.Contains("Torch")) {
                lit.enabled = true;
                unlit.enabled = false; 
            }
        }
    }
}
