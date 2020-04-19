using UnityEngine;
using System.Collections;

public class FinalBoss : Enemy
{
    // Use this for initialization
    public override void Start()
    {
        base.Start(); 
        maxHealth = 200; 
        currentHealth = 200; 
        contact_damage = 1;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update(); 
    }
    
    /* Takes damage, but only if the damage is 5 or above */ 
    override public void takeDamage(int x) { 
        if (x < 5) {
            x = 0;
        }
        base.takeDamage(x); 
    }
}
