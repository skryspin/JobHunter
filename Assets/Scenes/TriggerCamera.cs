using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    public Transform CameraPosition; 
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MainCamera Position Updated: " + MainCamera.transform.position); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) { //only change camera position if its the player!
            MainCamera.GetComponent<MainCamera>().SetCameraPosition(CameraPosition);
        }
        
    }
    

}
