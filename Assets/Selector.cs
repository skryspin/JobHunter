using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Is used to select a particular answer during the boss fight */ 
public class Selector : MonoBehaviour
{
    public AnswerSelectionManager selectionManager; 
    
    public AnswerSelectionManager.Selection myChoiceEnum; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)  {
            selectionManager.select(myChoiceEnum); 
        }
    }
}
