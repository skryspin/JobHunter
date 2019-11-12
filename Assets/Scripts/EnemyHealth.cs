using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Enemy enemyScript;
    private Slider mySlider; 
    private int BUFFER = 60;
    private int currentBuffer = 0;     
    // Start is called before the first frame update
    void Start()
    {
        mySlider = this.GetComponent<Slider>();
        mySlider.minValue = 0;    
        mySlider.value = enemyScript.currentHealth; 
        mySlider.maxValue = enemyScript.maxHealth;   
       // firstframe = true; 
    
    }

    // Update is called once per frame
    void Update()
    {
       if (enemyScript.currentHealth <= 0 || enemyScript == null) {
            Destroy(this.gameObject); 
        }
        else {
            if (mySlider.value != enemyScript.currentHealth) {
                currentBuffer = BUFFER;  
                enableChildren(); 
            } 
            mySlider.maxValue = enemyScript.maxHealth;
            mySlider.value = enemyScript.currentHealth;
        }
        
        if (currentBuffer > 0) {
            currentBuffer--; 
        } 
        else {
            disableChildren();
        }
    }
    
    private void disableChildren() {
        Image[] images = this.gameObject.GetComponentsInChildren<Image>();
        foreach (Image x in images) {
            x.enabled = false;
        } 
    }
    
    private void enableChildren() {
        Image[] images = this.gameObject.GetComponentsInChildren<Image>();
        foreach (Image x in images) {
            x.enabled = true;
        } 
    } 
}