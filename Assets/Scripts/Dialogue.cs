using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public GameObject textObject; 
    private Text text; 
    public GameObject[] disableOrEnable; 
    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<Text>();
        hide();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void hide() {
        foreach (GameObject x in disableOrEnable) {
            x.SetActive(false);
        } 
    }
    
    private void show() {
        foreach (GameObject x in disableOrEnable) {
            x.SetActive(true);
        } 
    } 
    
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) { //only trigger if its the player!
            show();
        }
    }
    
    public void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) { //only trigger if its the player!
            hide();
        }
    }
}