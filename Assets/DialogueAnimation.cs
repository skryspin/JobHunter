using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogueAnimation : MonoBehaviour
{

    private Animation anim; //the animation component attached to this object
    public GameObject anchor; //the character from which the dialogue should stem
    public Vector3 offsets; //the offset from the anchor at which to float the UI elements
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>(); 
        foreach (UIFloat comp in this.GetComponentsInChildren<UIFloat>()) {
            comp.anchor = this.anchor;  //sets the anchor of all children
            comp.offset = this.offsets; //sets the offset of all children
        }
    }

    // Update is called once per frame
    void Update()
    {        
    }
    
    
    /* Dialogue objects will call this method to to trigger a set of dialogue, emerging from anchor */
    public void StartDialogue(string[] dialogue) {
        int i = 0;
        foreach (string speech in dialogue) {
            string clipname = "say" + i; 
            
            // creates a 2.5s animation clip with no movement using 2 keyframes
            AnimationClip clip = new AnimationClip(); 
            Keyframe[] keys;
            keys = new Keyframe[2];
            keys[0] = new Keyframe(0.0f, 0.0f);
            keys[1] = new Keyframe(2.5f, 0.0f);
            AnimationCurve curve = new AnimationCurve(keys);
            clip.SetCurve("", typeof(Transform), "localPosition.x", curve);
            clip.name = clipname; 
            clip.legacy = true; // must be marked as legacy to use with animation component
            
            
            //creates an animation event calling Say at 0.0 
            AnimationEvent sayEvent = new AnimationEvent();
            sayEvent.stringParameter = speech;
            sayEvent.time = 0.0f; 
            sayEvent.functionName = "Say"; 
            
            //creates an animation event calling Mute at 2.5 
            AnimationEvent muteEvent = new AnimationEvent();
            muteEvent.time = 2.5f; 
            muteEvent.functionName = "Mute"; 
            
            clip.AddEvent(sayEvent);
            clip.AddEvent(muteEvent); 
            
            
            anim.AddClip(clip, clipname); 
            anim.PlayQueued(clipname); 
            anim.RemoveClip(clipname); 
            
            i++; 
        }
    }
    
    public void Say(string words) {
    
        this.GetComponentInChildren<Text>().text = words;
        foreach (Image x in this.GetComponentsInChildren<Image>()) {
            x.enabled = true; 
        }

        Debug.Log("Called say with " + words); 
    }
    
    public void Mute() {
        this.GetComponentInChildren<Text>().text = "";
        foreach (Image x in this.GetComponentsInChildren<Image>()) {
            x.enabled = false; 
        }

        Debug.Log("Called mute"); 

    }
}
