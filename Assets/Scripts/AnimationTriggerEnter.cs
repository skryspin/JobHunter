using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach to an object to trigger, or specify trigger object in editor
public class AnimationTriggerEnter : MonoBehaviour
{
    
    public string paramToTrigger; 
    public GameObject otherObjectToTrigger; 
    public string otherObjectParamToTrigger; 
    public bool debug; 
    public bool NonPlayerCanTrigger; //otherwise, just the player triggers
    
    private GameObject targetObject; 
    private Animator targetAnimator; 
    private Animator otherAnimator; 
    // Start is called before the first frame update
    void Start()
    {
        targetObject = this.gameObject; 
        targetAnimator = targetObject.GetComponent<Animator>();
        otherAnimator = otherObjectToTrigger.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other) {
        if ((other.gameObject.GetComponent<Player>() != null) || NonPlayerCanTrigger) {
            if (debug == true) {
                Debug.Log("Setting trigger " + paramToTrigger); 
            }
            if (targetAnimator != null) {
                targetAnimator.SetTrigger(paramToTrigger);
            }
            if (otherAnimator != null) {
                otherAnimator.SetTrigger(otherObjectParamToTrigger); 
            }
        }
    }
}
