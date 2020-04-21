using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobOffer : MonoBehaviour
{

    public GameObject icon; 
    DialogueTrigger dt; 
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false); 
        dt = this.gameObject.GetComponent<DialogueTrigger>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) {
            icon.SetActive(true); 
            Invoke("levelComplete", 9); 
            Destroy(this.gameObject.GetComponent<Collider>());
            this.gameObject.GetComponent<Renderer>().enabled = false; 
        }
    }
    
    public void levelComplete(){
        GameController.currentLevelController.levelComplete();
    }

}
