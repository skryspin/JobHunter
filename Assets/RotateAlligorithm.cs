using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlligorithm : MonoBehaviour
{

    public float normalSpeed; 
    public float slowSpeed; 
    public bool slowAtTopOfRotation = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed;
        if (slowAtTopOfRotation && this.transform.localRotation.z > -0.4 && this.transform.localRotation.z < 0.4) {
            speed = slowSpeed;
        }
        else {
            speed = normalSpeed;
        }
        transform.Rotate (0, 0,  ( speed * Time.deltaTime ), Space.Self );
        Debug.Log(this.transform.localRotation.z);

    }
}
