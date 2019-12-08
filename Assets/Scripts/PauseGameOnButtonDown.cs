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
            Pause(); 
        }
    }
    
    public static void UnPause() {            
        GameObject[] all = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject x in all) {
        
            foreach (MonoBehaviour script in x.GetComponents<MonoBehaviour>()) {
                /* Toggle scripts on and off */
                if (!script.gameObject.CompareTag("DoNotDisableOnPause")) {
                    script.enabled = true; 
                }
            }
         
            
            foreach (NavMeshAgent mesh in x.GetComponents<NavMeshAgent>()) {
                /* Toggle scripts on and off */
                if (!mesh.gameObject.CompareTag("DoNotDisableOnPause")) {
                    mesh.enabled = true; 
                }

            }
            
            foreach (Animator anim in x.GetComponents<Animator>()) {
                /* Toggle scripts on and off */
                if (!anim.gameObject.CompareTag("DoNotDisableOnPause") ) {
                    anim.speed = 1; 
                }
            } 
        }
    }
    

    
    public static void Pause() {
        GameObject[] all = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject x in all) {
            foreach (MonoBehaviour script in x.GetComponents<MonoBehaviour>()) {
            
                /* Toggle scripts on and off */
                if (script.enabled && !script.gameObject.CompareTag("DoNotDisableOnPause")) {
                    script.enabled = false; 
                }
            }
         
            
            foreach (NavMeshAgent mesh in x.GetComponents<NavMeshAgent>()) {
                /* Toggle scripts on and off */
                if (mesh.enabled && !mesh.gameObject.CompareTag("DoNotDisableOnPause")) {
                    mesh.enabled = false; 
                }

            }
            
            foreach (Animator anim in x.GetComponents<Animator>()) {
                /* Toggle scripts on and off */
                if (anim.speed == 1 && !anim.gameObject.CompareTag("DoNotDisableOnPause") ) {
                    anim.speed = 0; 
                }
            } 
        }
    }
    
}
