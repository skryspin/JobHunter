using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public GameObject dialogueAnimation; 
    private DialogueAnimation dialogueAnimationToTrigger;
    private bool triggered = false;
    
    public bool triggerOnlyOnce; 
    public string[] dialogue; 
    public bool proximityPlayOnly = false; //use for one-line text that should only play while player is in range
    
    public bool disableOnParentPickup; //stop dialogue if a parent object of this is picked up
    
    

    // Start is called before the first frame update
    void Start()
    {
        if (!this.gameObject.GetComponent<Collider>()) {
            Debug.LogError(this.gameObject.ToString() + ": This DialogueTrigger has no Collider attached");
        }
        dialogueAnimationToTrigger = dialogueAnimation.gameObject.GetComponent<DialogueAnimation>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<Pickup>() != null && this.GetComponentInParent<Pickup>().isHeld && disableOnParentPickup) {
            dialogueAnimationToTrigger.Mute(); 
        }
        
    }
    
    public void OnTriggerEnter(Collider other) {
    if ((triggerOnlyOnce && !triggered) || (!triggerOnlyOnce)) {
        if (this.enabled) {
                if (other.gameObject.GetComponent<Player>() != null && playerEnabled()) { //only trigger if its the player!
                    if (!proximityPlayOnly) {
                        dialogueAnimationToTrigger.StartDialogue(dialogue); 
                        Debug.Log("Triggering dialogue sequence..."); 
                        triggered = true;                     
                    }
                    else {
                        dialogueAnimationToTrigger.Say(dialogue[0]);
                    }
                }
            }
        }
    }
    
    public void OnTriggerStay(Collider other) {
        if ((triggerOnlyOnce && !triggered) || (!triggerOnlyOnce)) {
            if (this.enabled) {
                if (other.gameObject.GetComponent<Player>() != null && playerEnabled()) { //only trigger if its the player!
                    if (!proximityPlayOnly) {
                        dialogueAnimationToTrigger.StartDialogue(dialogue); 
                        Debug.Log("Triggering dialogue sequence..."); 
                        triggered = true; 
                    }
                    else {
                        dialogueAnimationToTrigger.Say(dialogue[0]);
                    }
                }
            }
        }
    }
    
    public void OnTriggerExit(Collider other) {
        if ((triggerOnlyOnce && !triggered) || (!triggerOnlyOnce)) {
            if (this.enabled) {
                if (proximityPlayOnly) {
                    if (other.gameObject.GetComponent<Player>() != null && playerEnabled()) { //only trigger if its the player!
                        dialogueAnimationToTrigger.Mute();
                    }
                }
            }
        }
    }
    
    private bool playerEnabled() {
        if (GameObject.FindWithTag("Player").gameObject.GetComponent<Player>().enabled) {
            return true;
        }
        else {
            return false; 
        }
    }
   
    

}