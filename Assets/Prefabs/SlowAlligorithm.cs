using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAlligorithm : MonoBehaviour
{
    public float MySlowSpeed;
    
    private float previousNormalSpeed; 
    private float previousSlowSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        previousNormalSpeed = this.transform.parent.GetComponent<RotateAlligorithm>().normalSpeed; 
        previousSlowSpeed = this.transform.parent.GetComponent<RotateAlligorithm>().slowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) {
            previousNormalSpeed = this.transform.parent.GetComponent<RotateAlligorithm>().normalSpeed;
            previousSlowSpeed = this.transform.parent.GetComponent<RotateAlligorithm>().slowSpeed;

            this.transform.parent.GetComponent<RotateAlligorithm>().normalSpeed = MySlowSpeed;
            this.transform.parent.GetComponent<RotateAlligorithm>().slowSpeed = MySlowSpeed;
            
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
         if (other.GetComponent<Player>() != null) {
            this.transform.parent.GetComponent<RotateAlligorithm>().normalSpeed = previousNormalSpeed;


        }
    }
}
