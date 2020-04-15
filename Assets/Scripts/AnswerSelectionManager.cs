using UnityEngine;
using System.Collections;

/* This class tracks which answer is currently selected and displays the relevant
 * UI effects that highlight the selected answer. It works with Boss to decide
 * whether a question is currently being asked (by calling isSelecting()), to determine whether it should
 * show its effects. */
public class AnswerSelectionManager : MonoBehaviour
{
    
    public Player player; //the player
    
    public Boss boss; //the boss

    public Selector choiceASelector; //the Selector for A
    public Selector choiceBSelector; 
    
    public GameObject answerA; // the box for answer A
    public GameObject answerB; // the box for answer B

    public GameObject LineObject; 
    public enum Selection {A, B}
    
    private Selection selected = Selection.A; 
    
    LineRenderer line; 
    
    public Material a; 
    public Material b; 
    
    // Use this for initialization
    void Start()
    {
        line = LineObject.GetComponent<LineRenderer>(); 
    }

    // Must be called after camera's LateUpdate to ensure proper positioning of line
    public void SuperLateUpdate()
    {
        if (boss.isSelecting()) //determines whether to show its effects
        {
            Debug.Log( "The selected value is " + selected ) ; 
            
            line.positionCount = 2 ;                
            Vector3 pos = (player.gameObject.transform.position);
            line.SetPosition(0, pos); 
            
            if (selected == Selection.A) {
                line.material = a; 
                pos = answerA.transform.position;
                line.SetPosition(1, pos); 
                                Debug.Log("A position: " + pos ) ; 

            }
            else {
                line.material = b; 
                pos = answerB.transform.position;
                line.SetPosition(1, pos); 
                Debug.Log("B position: " + pos ) ; 
            }
        }
        else {
            line.positionCount = 0; //erase the line
        }
    }
    
    public void select(Selection val) {
        selected = val; 
    }
    
    public Selection GetSelected() {
        return selected; 
    }
}
