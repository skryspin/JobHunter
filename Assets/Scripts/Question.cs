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
    private GameObject answerA;
    private Text textA;
    private GameObject answerB;
    private Text textB; 
    
    public static Text correct;
    public static Text incorrect; 
    
    
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
    public  Question(string q, Choice c, 
            GameObject questionbox, Text textbox, 
            GameObject aBox,  Text textA,
            GameObject bBox, Text textB)
    {
        question = q;
        choice = c; 
        this.questionbox = questionbox; 
        this.textbox = textbox; 
        answerA = aBox;
        answerB = bBox; 
        this.textA = textA;
        this.textB = textB; 
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
        textA.text = choice.getChoiceA().getText();
        answerA.SetActive(true); 

        Debug.Log("B: " + choice.getChoiceB().getText());
        textB.text = choice.getChoiceB().getText();
        answerB.SetActive(true); 

    }
    
    public void ShowResult(Answer answer) {
        Debug.Log("Answer: " + choice.getCorrect().getText());
        if (answer == getCorrectAnswer() ) {
            Debug.Log("Correct!");
            enableCorrect(); 
        }
        else {
            Debug.Log("Incorrect!");
            enableIncorrect();
        }
    }
    
    public void finish() {
        isDone = true; //marks as done
        
        disableCorrectness();
        
        //hide UI elements
        textbox.text = " "; 
        questionbox.SetActive(false);
        textA.text = " ";
        answerA.SetActive(false); 
        textB.text = " ";
        answerB.SetActive(false); 
    }
    
    void enableCorrect() {
        correct.enabled = true; 
        correct.transform.GetChild(0).GetComponent<Text>().enabled = true; 


    } 
    
    void disableCorrectness() {
        correct.enabled = false; 
        correct.transform.GetChild(0).GetComponent<Text>().enabled = false;
        incorrect.enabled = false; 
        incorrect.transform.GetChild(0).GetComponent<Text>().enabled = false; 
    }
    
    void enableIncorrect() {
        incorrect.enabled = true; 
        incorrect.transform.GetChild(0).GetComponent<Text>().enabled = true; 
    }
    
    
}
