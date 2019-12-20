using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


/* This class holds data vital to the overall game: Levels locked and unlocked, completed, and control settings */
public class GameController : MonoBehaviour
{
    static public string mode = "Joycon"; 
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameController") != this.gameObject) {
            GameObject.Destroy(this.gameObject); 
        }
        
        GameObject.DontDestroyOnLoad(this.gameObject); //we must keep this during the whole game! (even save it)
        
    }

    // Update is called once per frame
     void Update()
    {
        toggleMode(); //handles toggling control method
       
    }
    
    static private bool toggleMode() {
        //Debug.Log("before: " + mode);

        //Debug.Log("Inside toggle"); 
        if ((mode == "Keyboard") && (Input.GetButton("Jump"))) {
            mode = "Joycon";
            Debug.Log(mode);
            return true; 
        }
        else if ((mode == "Joycon") && ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) ) {
            mode = "Keyboard";
            Debug.Log(mode);

            return true; 
        }
        return false; 
    }

  
}
