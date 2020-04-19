using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeaponPickup : MonoBehaviour
{
    public GameObject specialResumeProjectile; 
    public GameObject normalResumeProjectile;
    
    public Player p; 
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
        if (other.gameObject.GetComponent<Player>() != null) {
            p = other.gameObject.GetComponent<Player>(); 
            givePowerUp();
            
            this.GetComponent<BoxCollider>().enabled = false; //make this disappear
            
            foreach (Renderer r in this.GetComponentsInChildren<Renderer>()) { //make this disappear
                r.enabled = false;
            } 
        }
            
    }
    
    
    private void givePowerUp() {
        p.resumePrefab = specialResumeProjectile; 
        Invoke("removePowerUp", 10); 
    }
    
    private void removePowerUp() {
        p.resumePrefab = normalResumeProjectile;
        Destroy(this.gameObject); 
    }
}
