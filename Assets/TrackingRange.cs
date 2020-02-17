using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingRange : MonoBehaviour
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy.target) {
            enemy.gameObject.GetComponent<Animator>().SetTrigger("LostTarget");
        }
    }
}
