using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController
{
    Player player; 
    int requiredCollectables; 
    
    public DialogueTrigger missingRequirements; 

    // Start is called before the first frame update
    public LevelController()
    {
        missingRequirements = GameObject.Find("MissingRequirements").GetComponent<DialogueTrigger>(); 
        Debug.Log("Level constructor for scene " + SceneManager.GetActiveScene().name); 
        player = GameObject.FindObjectOfType<Player>(); 
        requiredCollectables = GameObject.FindGameObjectsWithTag("RequiredCollectable").Length;
    }


    public void PlayerHasRequiredItems()
    {
        Debug.Log("Checking if player has required items."); 
        Debug.Log("Score: " + player.score);
        Debug.Log("RequiredCount: " + requiredCollectables); 

        if (player.score == requiredCollectables) {
                Debug.Log("Score: " + player.score);
                Debug.Log("RequiredCount: " + requiredCollectables); 
                levelComplete();
        }
        else if (player.score < requiredCollectables) {
            missingRequirements.enabled = true; 
        }
    }
    
    private void levelComplete() {
        Debug.Log("Level Complete!"); 
        GameObject.Find("LevelComplete").GetComponent<Animator>().SetTrigger("Complete");
    }
}
