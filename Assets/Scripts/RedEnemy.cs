using UnityEngine;
using System.Collections;

public class RedEnemy : Enemy
{
    // Use this for initialization
    public override void Start()
    {
        currentHealth = 1;
        maxHealth = 1; 
        contact_damage = 1; 

    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        GameObject cuddleBuddy = other.gameObject;
        Debug.Log("Collision detected with: " + cuddleBuddy);


        
        if (cuddleBuddy.GetComponent<Player>() != null)
        {
            Player player = cuddleBuddy.GetComponent<Player>(); 
            player.TakeDamage(contact_damage);
        }
    }
}
