﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.EventSystems;
using System; 
using System.Runtime.Serialization.Formatters.Binary;
using System.IO; 


/* This class holds data vital to the overall game: Levels locked and unlocked, completed, and control settings */
public class  GameController : MonoBehaviour
{
    static public string mode = "Joycon"; 
    static public string levelBeingLoaded = null; 
    static public LevelController currentLevelController; 
    static private string[] validLevelNames = {"Level1", "Level2", "Boss"};
    
    static private List<string> newLevels;
    static private List<string> oldLevels;



    
    /* Unlocks the level that comes after scenename */ 
    static public void unlockLevelAfter(string levelname) {
            switch (levelname) {
                case "Level1":
                    if (!oldLevels.Contains("Level2") && !newLevels.Contains("Level2")) {
                        newLevels.Add("Level2");
                    }
                    break;
                case "Level2":
                    if (!oldLevels.Contains("Boss") && !newLevels.Contains("Boss"))
                        newLevels.Add("Boss");
                    break;
                default:
                    
                    break; 
            }
    }
    
    /* Plays the unlock animation for new levels, but sets old levels to already be unlocked */ 
    static public void unlockLevels() {
        foreach (string x in newLevels) {
            GameObject.Find(x).GetComponent<Level>().unlock();  //plays unlock for new levels
        }
        foreach (string x in oldLevels) {
            GameObject.Find(x).GetComponent<Level>().alreadyUnlocked(); //skips unlock animation and just displays level
        }
        foreach (string x in newLevels) {
            if (!oldLevels.Contains(x)) {
                oldLevels.Add(x);           //adds newlevel to oldlevel
            }
        }
        newLevels.Clear();  //all new levels have been added, hurray
    }
    

    // Start is called before the first frame update
    void Start()
    {
        /* Creates the 2 unlockable levels */
        if (GameObject.Find("GameController") != this.gameObject) {
            GameObject.Destroy(this.gameObject); 
        }
        else {
            newLevels = new List<string>(); 
            oldLevels = new List<string>(); 
            currentLevelController = new LevelController(); //instantiate on scene load
            GameObject.DontDestroyOnLoad(this.gameObject); //we must keep this during the whole game! (even save it)
        }
        
    }
    
    

    
    /* Debugging method */ 
    void printLevels() {
        Debug.Log("printing levels"); 
        string n = "new: ";
        string o = "old: ";
        foreach (string x in newLevels) {
            n = n + x + " "; 
        }
        foreach (string x in oldLevels) {
            o = o + x + " "; 
            
        }
        Debug.Log(n);
        Debug.Log(o); 
    } 
    
    // Update is called once per frame
     void Update()
    {
        if (Input.GetButtonDown("JumpJoy")) {
            Debug.Log("Pressing JumpJoy"); 
        }
        if (Input.GetButton("JumpJoy")) {
            Debug.Log("Holding JumpJoy"); 
        }
        if (Input.GetButtonUp("JumpJoy")) {
            Debug.Log("Releasing JumpJoy"); 
        }
             if (Input.GetButtonDown("Jump")) {
            Debug.Log("Pressing Jump"); 
        }
        if (Input.GetButton("Jump")) {
            Debug.Log("Holding Jump"); 
        }
        if (Input.GetButtonUp("Jump")) {
            Debug.Log("Releasing Jump"); 
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            GameObject.Find("Main Camera").GetComponent<FreeCamera>().enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.C)) {
            GameObject.Find("Main Camera").GetComponent<FreeCamera>().enabled = true;
        }
        toggleMode(); //handles toggling control method
        setAxis();
        checkLevelLoaded(); 
//        Debug.Log("active scene: " + SceneManager.GetActiveScene().name); 
        if (SceneManager.GetActiveScene().name == "LevelSelect") {
            unlockLevels();
        }
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
                Debug.Log("mode: " + mode); 

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

    private void OnDestroy()
    {
        Debug.Log("Destroying GC with ID" + this.GetInstanceID());
    }
    
    public void Save() {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath + "/saveData.dat");
        
        Debug.Log("Saving to " + Application.persistentDataPath + "/saveData.dat" ); 
        SaveData sd = new SaveData();
        sd.newLevels = newLevels; 
        sd.oldLevels = oldLevels;
        
        bf.Serialize(file, sd); //serializes save data to saveData.dat
        file.Close(); 
    }
    
    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/saveData.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.Open);
            Debug.Log("Loading from " + Application.persistentDataPath + "/saveData.dat" ); 

            SaveData data = (SaveData) bf.Deserialize(file);
            file.Close();
            
            oldLevels = data.oldLevels;
            newLevels = data.newLevels; 
        }
    }
}

[Serializable]
class SaveData {
    public List<string> newLevels; 
    public List<string> oldLevels; 
} 
