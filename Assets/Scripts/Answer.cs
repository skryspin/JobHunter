using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer
{
    private string text;
    private bool correct; 
    
    public Answer(string text, bool isCorrect) {
        this.text = text; 
        this.correct = isCorrect; 
    }
    
    public bool isCorrect() {
        return correct;
    }
    
    public string getText() {
        return text;
    }
}