using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectPositions : MonoBehaviour
{
    [SerializeField] private GameObject parentOfPositionChildren; // should not change dynamically
    private List<Transform> positions; //only should be changed in start
    private int currentPositionIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = parentOfPositionChildren.GetComponent<Transform>();
        Transform[] transforms = parentOfPositionChildren.GetComponentsInChildren<Transform>();
        positions = new List<Transform>(); 
        foreach (Transform x in transforms) {
            if (x.gameObject != parentOfPositionChildren) {
                positions.Add(x);
            }
        }
        currentPositionIndex = 0; 
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("CameraToggle")) {
            currentPositionIndex++;
            if (currentPositionIndex >= positions.Count) {
                currentPositionIndex = 0;
            }
        
        }
        this.gameObject.transform.position = positions[currentPositionIndex].transform.position;
        this.gameObject.transform.rotation = positions[currentPositionIndex].transform.rotation;
        this.gameObject.transform.localScale = positions[currentPositionIndex].transform.localScale;
    }
}
