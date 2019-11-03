using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject MainCamera; 
    
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(MainCamera.transform);
    }
}
