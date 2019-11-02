using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject parent; 

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject.transform.parent.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) {
            Debug.Log("Player exiting from Hitbox"); 

            parent.GetComponent<Enemy>().takeDamage(1); 
        }
    }
}
