using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    public Image sprite; //sprite to enable on collection, should be in a canvas
    
    // Start is called before the first frame update
    void Start()
    {
        if (sprite ==  null) {
            Debug.LogError("Needs a sprite");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null && this.enabled) {
            GameController.currentLevelController.Collect(sprite);
            Destroy(this.gameObject); 
        }
    }
}
