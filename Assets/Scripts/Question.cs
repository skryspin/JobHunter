using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;


public class Question 
{

    //Private fields
    private string question;
    private Choice choice; 
    private bool isDone = false;
    private GameObject questionbox; 
    private Text textbox; 
    
    public bool IsDone {
        get
        {
            return isDone; 
        }
        private set 
        {
            isDone = value;
        }
    }
    
    //Constructor
    public Question(string q, Choice c, GameObject questionbox, Text textbox) {
        question = q;
        choice = c; 
        this.questionbox = questionbox; 
        this.textbox = textbox; 
        Debug.Log(textbox.text); 
    }
    
    public string getQuestion() {
        return question;
    }
    
    public Choice getChoice() {
        return choice;
    }
    
    public Answer getCorrectAnswer() {
        return choice.getCorrect();
    }
    
    /* Ask the question */ 
    public void Ask() {
        Debug.Log(question);
        questionbox.SetActive(true); 
        textbox.text = getQuestion(); 
    }
    
    public void ShowChoices() {
        Debug.Log("A: " + choice.getChoiceA().getText());
        Debug.Log("B: " + choice.getChoiceB().getText());
    }
    
    public void ShowAnswer() {
        Debug.Log("Answer: " + choice.getCorrect().getText());
    }
    
    public void finish() {
        isDone = true; 
        textbox.text = " "; 
        questionbox.SetActive(false);
    }
    
    
}
