using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfButtonsPressed : MonoBehaviour
{
    public List<GameObject> buttons; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool allAreOpen = true; 
        foreach (GameObject button in buttons) {
            Animator anim = button.GetComponent<Animator>();
            if (anim != null) {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Pressed")) {
                    allAreOpen = false; 
                    break;
                }
            }
        }
        if (allAreOpen && this.gameObject.GetComponent<Collider>().enabled) {
            Debug.Log("Disabling " + this.gameObject.name + "'s  collider."); 
            this.gameObject.GetComponent<Collider>().enabled = false; 
        }        
    }
}
