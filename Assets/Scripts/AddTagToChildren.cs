using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTagToChildren : MonoBehaviour
{
    // Start is called before the first frame update
    
    public string TagToAdd; 
    void Start()
    {
        foreach (Transform child in this.transform.GetComponentsInChildren<Transform>()) {
            child.tag = TagToAdd; 
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
