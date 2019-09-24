using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectPositions : MonoBehaviour
{
    [SerializeField] private GameObject parentOfPositionChildren; // should not change dynamically
    private Component[] positions; //should not change dynamically
    private int currentPositionIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        positions = parentOfPositionChildren.GetComponentsInChildren<Transform>();
        currentPositionIndex = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("CameraToggle")) {
            currentPositionIndex++;
            if (currentPositionIndex >= positions.Length) {
                currentPositionIndex = 0;
            }
        
        }
        this.gameObject.transform.position = positions[currentPositionIndex].transform.position;
        this.gameObject.transform.rotation = positions[currentPositionIndex].transform.rotation;
        this.gameObject.transform.localScale = positions[currentPositionIndex].transform.localScale;
    }
}
