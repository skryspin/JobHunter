using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Axis 1 Raw: " +  Input.GetAxisRaw("Axis 1")); 
        Debug.Log("Axis 2 Raw: " + Input.GetAxisRaw("Axis 2")); 
    }
}
