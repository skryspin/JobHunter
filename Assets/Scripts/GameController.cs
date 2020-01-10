using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.EventSystems;


/* This class holds data vital to the overall game: Levels locked and unlocked, completed, and control settings */
public class  GameController : MonoBehaviour
{
    static public string mode = "Joycon"; 
    static public string levelBeingLoaded = null; 
    static public LevelController currentLevelController; 
    static private string[] validLevelNames = {"Level1"}; 
    
    
    // Start is called before the first frame update
    void Start()
    {
    
        if (GameObject.Find("GameController") != this.gameObject) {
            GameObject.Destroy(this.gameObject); 
        }
        currentLevelController = new LevelController(); //instantiate on scene load
        
        GameObject.DontDestroyOnLoad(this.gameObject); //we must keep this during the whole game! (even save it)
        
    }

    // Update is called once per frame
     void Update()
    {
        toggleMode(); //handles toggling control method
        setAxis();
        checkLevelLoaded(); 
        Debug.Log("currentLevelController: " + currentLevelController);
    }
    
    /* Sets the horizontal axis of the EventSystem based on the current mode */ 
    static private void setAxis() {
        EventSystem eventSystem = EventSystem.current;
        if (eventSystem != null) {
            StandaloneInputModule inputModule = eventSystem.gameObject.GetComponent<StandaloneInputModule>();
            string before = inputModule.horizontalAxis; 
            if (mode == "Joycon") {
                inputModule.horizontalAxis = "HorizontalJoy";
                inputModule.verticalAxis = "VerticalJoy"; 

            }
            else if (mode == "Keyboard") {
                inputModule.horizontalAxis = "Horizontal";
                inputModule.verticalAxis = "Vertical"; 
 
            }
            if (before != inputModule.horizontalAxis) {
                Debug.Log("Changed axis to " + inputModule.horizontalAxis);
            }
        }
    }
    
    static private bool toggleMode() {
        //Debug.Log("before: " + mode);
        //Debug.Log("mode: " + mode); 
        //Debug.Log("Inside toggle"); 
        if ((mode == "Keyboard") && (Input.GetButton("JumpJoy"))) {
            mode = "Joycon";
            Debug.Log("mode: " + mode);
            return true; 
        }
        else if ((mode == "Joycon") && ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) ) {
            mode = "Keyboard";
            Debug.Log("mode: " + mode);
            return true; 
        }
        return false; 
    }
    
    
    /* Loads a level, if it is valid. Otherwise, reports an error. */ 
    static public void LoadLevel(string sceneName) {
        if (isValidLevel(sceneName)) {
            levelBeingLoaded = sceneName; 
            SceneManager.LoadScene(sceneName); 
        }
        else {
            Debug.LogError(" '" + sceneName + "' is not a valid level name. " +
            "Please add it to the GameController script if it is a valid level.");
        }
    }
    
    static public void checkLevelLoaded() {
        if (levelBeingLoaded != null) {
            if (SceneManager.GetSceneByName(levelBeingLoaded).isLoaded) {
                Debug.Log("Instantiating level controller") ;
                LevelController lvl = new LevelController();
                GameController.currentLevelController = lvl; 
                levelBeingLoaded = null; 
            }
        }
    }
    
    
    /* Checks whether a sceneName is a valid level. Returns a bool */ 
    static public bool isValidLevel(string sceneName) {
        foreach (string name in validLevelNames) {
            if (sceneName == name) {
                return true; 
            }
        }
        return false; 
    }

  
}
