using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChaseRange : MonoBehaviour
{

    public NavigableEnemy enemy; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy.target) {
            enemy.anim.SetTrigger("SawPlayer");
        }
    }
}
