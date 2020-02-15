using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunchDetector : MonoBehaviour
{
    public Animator animator; 
    private float startingSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        startingSpeed = this.transform.parent.transform.parent.GetComponent<RotateAlligorithm>().normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled) {
            if (other.GetComponent<Player>() != null) {
                this.transform.parent.transform.parent.GetComponent<RotateAlligorithm>().normalSpeed = startingSpeed;
                animator.SetTrigger("MunchTime");
                Debug.Log("It'sssss munchtime!");
            }
        }
    }
}
