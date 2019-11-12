using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.AI; 

public class PauseGameOnButtonDown : MonoBehaviour
{
    public string btnName; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(btnName)) {
            TogglePause(); 
        }
    }
    
    public static void TogglePause() {
            GameObject[] all = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject x in all) {
                foreach (MonoBehaviour script in x.GetComponents<MonoBehaviour>()) {
                
                    /* Toggle scripts on and off */
                    if (script.enabled && !script.gameObject.CompareTag("DoNotDisableOnPause")) {
                        script.enabled = false; 
                    }
                    else {
                        script.enabled = true; 
                    }
                }
                
                foreach (NavMeshAgent mesh in x.GetComponents<NavMeshAgent>()) {
                    /* Toggle scripts on and off */
                    if (mesh.enabled && !mesh.gameObject.CompareTag("DoNotDisableOnPause")) {
                        mesh.enabled = false; 
                    }
                    else {
                        mesh.enabled = true; 
                    }
                }
                
                foreach (Animator anim in x.GetComponents<Animator>()) {
                    /* Toggle scripts on and off */
                    if (anim.enabled && !anim.gameObject.CompareTag("DoNotDisableOnPause") ) {
                        anim.enabled = false; 
                    }
                    else {
                        anim.enabled = true; 
                    }
                }
   
            
        }
    
    }
}
