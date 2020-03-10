using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isHeld; 
    public Vector3 holdOffset; 
    public GameObject destinationTriggerObj; 
    public GameObject destinationPosition; 
    public GameObject destinationParent; //the parent that holds all the keyboard keys 
    private Collider destinationTrigger; 
    void Start()
    {
        destinationTrigger = destinationTriggerObj.GetComponent<Collider>(); 
        holdOffset = new Vector3(0, 1.8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered by " + other.name); 
        if (!isHeld && other == destinationTrigger) { //only if the item is not held
            Debug.Log("Putting the key in place..."); 
            this.destinationTrigger.GetComponent<DialogueTrigger>().dialogueAnimation.GetComponent<DialogueAnimation>().Mute();
            Destroy(this.destinationTrigger.GetComponent<DialogueTrigger>());
            this.transform.SetParent(destinationParent.transform);  
            this.transform.localPosition = destinationPosition.transform.localPosition; 
            this.transform.localRotation = destinationPosition.transform.localRotation; 
            this.transform.localScale = destinationPosition.transform.localScale; 
            this.gameObject.GetComponentInChildren<Animator>().SetTrigger("Place"); 
            this.gameObject.tag = "Untagged"; //no longer pickupable
            Destroy(this.gameObject.GetComponentInChildren<DialogueTrigger>().gameObject);
            Destroy(this); 
        }

    }
}
