using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController
{
    Player player; 
    int requiredCollectables; 
    
    
    public DialogueTrigger missingRequirements; 

    // Start is called before the first frame update
    public LevelController()
    {
        try {
        missingRequirements = GameObject.Find("MissingRequirements").GetComponent<DialogueTrigger>(); 
        }
        catch (NullReferenceException) {
            Debug.Log("missingRequirements is null"); 
        }
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
    
    public void levelComplete() {
        Debug.Log("Level Complete!"); 
        GameController.unlockLevelAfter(SceneManager.GetActiveScene().name);
        GameObject.Find("LevelComplete").GetComponent<Animator>().SetTrigger("Complete");
    }
    
    public void Collect(Image sprite) {
        sprite.enabled = true;
        player.score++;
    }
}
