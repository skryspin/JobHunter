using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayAnimatorStart : MonoBehaviour
{

    public float delayBy;
    public bool delayStart; 
    // Start is called before the first frame update
    void Start()
    {
        if (delayStart)
        {
                this.GetComponent<Animator>().enabled = false; 
                Invoke("EnableAnimator", delayBy); //starts it up later
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void EnableAnimator () {
        this.GetComponent<Animator>().enabled = true; 
    }
}
