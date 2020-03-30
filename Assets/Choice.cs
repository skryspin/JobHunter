using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice
{
    private Answer choiceA;
    private Answer choiceB; 
    
    public Choice(Answer first, Answer second) {
        bool a = first.isCorrect();
        bool b = second.isCorrect(); 
        if ((a==b) || (first == second)) {
            Debug.LogError("Error: Exactly one of the Answers must be correct, and they cannot be the same Answer.");
            return;  
        }
        else {
            choiceA = first;
            choiceB = second;
        }
    }
    
    public Answer getCorrect() {
        if (choiceA.isCorrect()) {
            return choiceA;
        }
        else {
            return choiceB;
        }
    }
    
    public Answer getChoiceA() {
        return choiceA;
    }
    
    public Answer getChoiceB() {
        return choiceB;
    }
}
