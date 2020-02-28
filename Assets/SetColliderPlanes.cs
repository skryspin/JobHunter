using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColliderPlanes : MonoBehaviour
{
    public GameObject[] planes; 
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (GameObject plane in planes) {
            this.gameObject.GetComponentInChildren<ParticleSystem>().collision.SetPlane(i, plane.transform); 
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
