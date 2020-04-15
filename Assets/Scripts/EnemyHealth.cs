using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Enemy enemyScript;
    protected Slider mySlider; 
    protected int BUFFER = 60;
    protected int currentBuffer = 0;     
    // Start is called before the first frame update
    protected void Start()
    {
        mySlider = this.GetComponent<Slider>();
        mySlider.minValue = 0;    
        mySlider.value = enemyScript.currentHealth; 
        mySlider.maxValue = enemyScript.maxHealth;   
       // firstframe = true; 
    
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //Debug.Log(currentBuffer); 
        if (currentBuffer > 0) {
            currentBuffer--; 
        } 
        else {
            disableChildren();
        }
        
        if (enemyScript.currentHealth == 0) {
            GameObject.Destroy(this.gameObject); 
        }
    }
    
    virtual public void display() {
        currentBuffer = BUFFER;  
        enableChildren(); 
        mySlider.maxValue = enemyScript.maxHealth;
        mySlider.value = enemyScript.currentHealth;

    }
    
    protected void disableChildren() {
        Image[] images = this.gameObject.GetComponentsInChildren<Image>();
        foreach (Image x in images) {
            x.enabled = false;
        } 
    }
    
    protected void enableChildren() {
        Image[] images = this.gameObject.GetComponentsInChildren<Image>();
        foreach (Image x in images) {
            x.enabled = true;
        } 
    } 
}