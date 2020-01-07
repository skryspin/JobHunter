using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class LoadLevelOnSubmit : MonoBehaviour
{
    public string sceneName; 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject) {
            if (Input.GetButton("Submit")) {
                this.gameObject.GetComponent<Animator>().SetTrigger("Pressed"); 
                Debug.Log("submitting");
                SceneManager.LoadScene(sceneName);
                LevelController.LevelController();  
            }
        }
    }
}
