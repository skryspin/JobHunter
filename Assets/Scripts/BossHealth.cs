using UnityEngine;
using System.Collections;

public class BossHealth : EnemyHealth 
{

    // Use this for initialization


    // Update is called once per frame
    protected override void Update()
    {   
        if (enemyScript.currentHealth == 0) {
            GameObject.Destroy(this.gameObject); 
        }
        display(); //display every frame
    }
    
    public override void display() {
        enableChildren(); 
        mySlider.maxValue = enemyScript.maxHealth;
        mySlider.value = enemyScript.currentHealth;
    }
}
