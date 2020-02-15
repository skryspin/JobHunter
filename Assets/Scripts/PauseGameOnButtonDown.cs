using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.AI; 

public class PauseGameOnButtonDown : MonoBehaviour
{
    public string btnName; 
    public static bool paused = false; 
    Player player; 

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindWithTag("Player").GetComponent<Player>();
         paused = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead) {
            if (Input.GetButtonDown(btnName)) {
                if (!paused) {
                    Debug.Log("pausing");
                    Pause(); 
                }
                else {
                    Debug.Log("unpauseing");
                    UnPause();
                }
            }
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
        paused = false; 
    }
    

    
    public static void Pause() {
        GameObject[] all = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject x in all) {
            foreach (MonoBehaviour script in x.GetComponents<MonoBehaviour>()) {
            
                /* Toggle scripts on and off */
                if (script.enabled && !script.gameObject.CompareTag("DoNotDisableOnPause") && script.gameObject.tag != "MainCamera") {
                    script.enabled = false; 
                    if (script.gameObject.name == "Main Camera")
                        Debug.LogError("BAD!");
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
        Camera.main.GetComponent<FreeCamera>().enabled = true; 
        paused = true; 
    }
    
}
