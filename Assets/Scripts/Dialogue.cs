using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    Player player; 
    public string[] dialogue; 

    // Start is called before the first frame update
    void Start()
    {
        player = (Player) GameObject.FindWithTag("Player").GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) { //only trigger if its the player!
            player.dialogueAnimation.StartDialogue(dialogue); 
        }
    }
    

}