using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public string myname; 
    private Animator animator; 
    private bool unlocked = false; //initialized to locked
    
    void Start() {
        animator = this.gameObject.GetComponent<Animator>(); 
        myname = this.gameObject.name; 

    }
    
    void Update() {

    }
    
    public void unlock() {
        unlocked = true;
        this.animator.SetTrigger("Unlock");
    }
    
    public void alreadyUnlocked() {
        unlocked = true;
        this.animator.SetTrigger("Unlocked");
    }
    
    /* Static method to get a specific level */ 
    //public static Level GetLevel(string name) {
    //    foreach (Level l in levels) {
    //        if (l.name == name) {
    //            return l;
    //        }
    //    }
    //    return null; 
    //}

        


}
