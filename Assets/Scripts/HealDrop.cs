using UnityEngine;
using System.Collections;

public class HealDrop : MonoBehaviour
{

    public int value; 
    // Use this for initialization
    void Start()
    {
        if (value == 0) {
            value = 1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
