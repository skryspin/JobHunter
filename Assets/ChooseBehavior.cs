using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBehavior : StateMachineBehaviour
{
    Animator a; 
    int swipecount = 0; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        a = animator; 
        TriggerRandom();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        a = animator; 
        TriggerRandom();

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
    
    private void TriggerRandom() {
    
        int choice = (int) Mathf.Round(Random.Range(0, 3)); //chooses a random int between 0 and 2
        if (swipecount >= 3) {
            a.SetTrigger("AskQuestion");
        }
        else {
            switch (choice) {
                case 0:
                    a.SetTrigger("Swipe");
                    swipecount++;
                    break;
                case 1:
                    a.SetTrigger("SwipeRight");
                    swipecount++;
                    break;
                case 2:
                    a.SetTrigger("AskQuestion");
                    swipecount = 0;
                    break; 
                case 3:
                    Debug.Log("Got 3... wow!"); 
                    break; 
            }
        }
    }
}
