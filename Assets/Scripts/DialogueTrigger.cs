using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public GameObject dialogueAnimation; 
    private DialogueAnimation dialogueAnimationToTrigger;
    public string[] dialogue; 
    public bool proximityPlayOnly = false; //use for one-line text that should only play while player is in range

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
        
    }
    
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) { //only trigger if its the player!
            if (!proximityPlayOnly) {
                dialogueAnimationToTrigger.StartDialogue(dialogue); 
                Debug.Log("Triggering dialogue sequence..."); 
            }
            else {
                dialogueAnimationToTrigger.Say(dialogue[0]);
            }
        }
    }
    
    public void OnTriggerStay(Collider other) {
        if (proximityPlayOnly) {
            if (other.gameObject.GetComponent<Player>() != null) { //only trigger if its the player!
                if (!proximityPlayOnly) {
                    dialogueAnimationToTrigger.StartDialogue(dialogue); 
                    Debug.Log("Triggering dialogue sequence..."); 
                }
                else {
                    dialogueAnimationToTrigger.Say(dialogue[0]);
                }
            }
        }
    }
    
    public void OnTriggerExit(Collider other) {
        if (proximityPlayOnly) {
            dialogueAnimationToTrigger.Mute();
        }
    }
    

}