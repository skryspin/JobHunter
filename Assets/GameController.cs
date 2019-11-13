using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


/* This class holds data vital to the overall game: Levels locked and unlocked, completed, and control settings */
public class GameController : MonoBehaviour
{
    static public string mode = "Keyboard"; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject); //we must keep this during the whole game! (even save it)
        
    }

    // Update is called once per frame
     void Update()
    {
        toggleMode(); //handles toggling control method
       
    }
    
    static private bool toggleMode() {
        Debug.Log("Inside toggle"); 
        if ((mode == "Keyboard") && (Input.GetKey("joystick button 16"))) {
            mode = "Joycon";
            return true; 
        }
        else if ((mode == "Joycon") && ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) ) {
            mode = "Keyboard";
            return true; 
        }
        return false; 
    }

  
}
