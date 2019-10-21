using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public int maxHealth; 
    public int currentHealth;
    protected int contact_damage; 
    public Vector3 spawnLocation;  
    public Vector3 spawnRotation;   
    
    protected bool dieOnNextFrame = false; 
    public abstract void Start(); 
    
    
    // Update is called once per frame
    public abstract void Update();
    
    public void takeDamage(int x) {
        currentHealth = currentHealth - x; 
        if (currentHealth <= 0) {
            dieOnNextFrame = true; 

        }

    }
    
}
