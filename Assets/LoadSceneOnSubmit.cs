using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneOnSubmit : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject) {
            if (Input.GetButton("Submit")) {
                SceneManager.LoadScene(scene); 
            }
        }
        
    }
}
