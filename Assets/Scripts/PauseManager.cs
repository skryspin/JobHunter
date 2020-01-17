using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseManager : MonoBehaviour
{
    public string sceneName; 
    public string buttonName;
    public Player player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown(buttonName)) {
            if (SceneManager.GetSceneByName(sceneName).name == null) {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive); 
            }
            else {
                //Debug.Log(SceneManager.GetSceneByName(sceneName).name); 
                SceneManager.UnloadSceneAsync(sceneName); 
            }
        }
        
    }
}
