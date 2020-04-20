using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; 

public class Save : MonoBehaviour
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
                gc.Save(); 
            }
        }
    }
}
