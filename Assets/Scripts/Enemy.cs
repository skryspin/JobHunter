using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth; 
    public int contact_damage; 
    
    public abstract void Start(); 
    
    // Update is called once per frame
    public abstract void Update();
}
