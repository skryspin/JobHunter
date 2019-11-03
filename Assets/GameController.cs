using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Player player; 
    GameObject[] requiredCollectables; 
    public Pickup requiredItem; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>(); 
        Debug.Log(player); 
        requiredCollectables = GameObject.FindGameObjectsWithTag("RequiredCollectable"); 
        Debug.Log(requiredCollectables[0]); 
                Debug.Log(requiredCollectables[1]); 
        Debug.Log(requiredCollectables[2]); 

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() == player) {
            if (player.score == requiredCollectables.Length && player.helditem == requiredItem) {
                levelComplete(); 
            }
        }
    }
    
    private void levelComplete() {
        Debug.Log("Level complete!"); 
    }
}
