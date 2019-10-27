﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTagToChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform.GetComponentsInChildren<Transform>()) {
            child.tag = "Collectable"; 
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
