using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public int maxHealth; 
    public int currentHealth;
    protected int contact_damage; 
    public Animator anim; 
    public EnemyHealth healthBar; 
    
    
    // Health Drops
    public GameObject healthSpawner; 
    public Vector3 healthOffset = new Vector3(0, 0, 0);  
    

    public Vector3 spawnLocation;  
    public Vector3 spawnRotation;   
    
    protected bool dieOnNextFrame = false; 
    
    public virtual void Start() {
        if (healthBar == null) {
            Debug.LogError("Must assign a healthBar to this object in the editor.");
        }

    }
    
    
    // Update is called once per frame
    virtual public void Update() {
        if(dieOnNextFrame) {
            Debug.Log("Instantiating " + Instantiate(healthSpawner, this.transform.position + healthOffset, this.transform.rotation));
            Destroy(this.gameObject); 
        } 
    }
    
    virtual public void takeDamage(int x) {
        currentHealth = currentHealth - x; 
        if (currentHealth <= 0) {
            dieOnNextFrame = true; 
        }
        else { 
            healthBar.display(); 
        }

    }
    
    public void OnTriggerEnter(Collider other) {
        GameObject cuddleBuddy = other.gameObject;
        //Debug.Log("Alligorithm collided with: " + cuddleBuddy);
        
        if (cuddleBuddy.GetComponent<Player>() != null)
        {
            Player player = cuddleBuddy.GetComponent<Player>(); 
            player.TakeDamage(contact_damage);
        }
    }
    
    public void OnTriggerStay(Collider other) {
       //
    }
    
    public void OnTriggerExit(Collider other) {
        //
    }
    
}
