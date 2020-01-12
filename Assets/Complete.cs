using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FOR DEBUG ONLY
        if (Input.GetKeyDown(KeyCode.Q)) {
            GameController.currentLevelController.levelComplete(); 
        }
    }
}
