using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{

    public Transform CameraPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = CameraPosition.position;
        this.gameObject.transform.rotation = CameraPosition.rotation;
        if (Input.GetButtonDown("Jump")) {
            this.gameObject.GetComponent<Animator>().SetTrigger("SkipCutscene");
        }

    }
    
    public void SetCameraPosition(Transform position) {
        if (position is null) {
            position = GameObject.Find("CameraPositions").transform.GetChild(0);
            Debug.Log("position: " + position);
        }
        CameraPosition = position; 
        this.gameObject.transform.position = CameraPosition.position;
        this.gameObject.transform.rotation = CameraPosition.rotation;
        Debug.Log("Updating Main Camera to position " + CameraPosition);
    }
}
