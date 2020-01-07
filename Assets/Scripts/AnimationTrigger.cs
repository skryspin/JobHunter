using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    
    public string paramToTrigger; 
    public GameObject targetObject; 
    public Animator targetAnimator; 
    public bool AnythingTriggers; //otherwise, just the player triggers
    // Start is called before the first frame update
    void Start()
    {
        if (targetAnimator == null) {
            targetAnimator = this.GetComponent<Animator>();
        }
        else {
            targetAnimator = targetObject.GetComponent<Animator>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerExit(Collider other) {
        if ((other.gameObject.GetComponent<Player>() != null) || AnythingTriggers) {
            targetAnimator.SetTrigger(paramToTrigger);
        }
    }
}
