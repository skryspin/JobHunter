using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Load : MonoBehaviour
{
    GameController gc;
    
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject) {
            if (Input.GetButton("Submit")) {
                this.gameObject.GetComponent<Animator>().SetTrigger("Pressed"); 
                gc.Load(); 
            }
        }
    }
}
