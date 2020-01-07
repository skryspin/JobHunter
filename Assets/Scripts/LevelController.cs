using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    static Player player; 
    static int requiredCollectables; 

    // Start is called before the first frame update
    static LevelController()
    {
        player = GameObject.FindObjectOfType<Player>(); 
        requiredCollectables = GameObject.FindGameObjectsWithTag("RequiredCollectable").Length; 
    }

    public static void PlayerHasRequiredItems()
    {
        Debug.Log("Checking if player has required items."); 
        Debug.Log("Score: " + player.score);
        Debug.Log("RequiredCount: " + requiredCollectables); 

        if (player.score == requiredCollectables) {
                Debug.Log("Score: " + player.score);
                Debug.Log("RequiredCount: " + requiredCollectables); 
                levelComplete();
        }
    }
    
    private static void levelComplete() {
        Debug.Log("Level Complete!"); 
        GameObject.Find("LevelComplete").GetComponent<Animator>().SetTrigger("Complete");
    }
}
