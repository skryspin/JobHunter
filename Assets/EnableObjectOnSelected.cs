using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnableObjectOnSelected : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject objectToEnable;
    
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject) {
            objectToEnable.SetActive(true); 
        }
        else {
            objectToEnable.SetActive(false); 
        }  
    }
}
