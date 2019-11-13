using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public GameObject player;
    private Player playerScript;
    private Slider mySlider; 
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        mySlider = this.GetComponent<Slider>();
        mySlider.minValue = 0;         
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript != null) {
            mySlider.maxValue = playerScript.maxHealth;
            mySlider.value = playerScript.currentHealth;
        }
    }
}
