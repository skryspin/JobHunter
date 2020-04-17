using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

/* Manages the asking / answering system for the boss battle */ 
public class Boss : MonoBehaviour
{
    Player player; 

    List<Question> questions = new List<Question>(); //list of questions that haven't been asked yet
    Question currentQuestion;   
    Animator animator;
    
    public GameObject questionbox; 
    private Text textBox; //where the question text is displayed
    
    public GameObject answerA;
    private Text textA; //where the answerA text is displayed
    
    public GameObject answerB;
    private Text textB; //where the answerB text is displayed
    
    private bool selecting = false; //is an answer selectable at this time? (i.e., the choices are displayed and the answer has not been shown) 
    AnswerSelectionManager asm; //class to manage which answer is selected 
    Answer playerAnswer; // the player's answer to the question
    
    public Text correct;
    public Text incorrect; 
    
    public GameObject SpecialWeaponPickup; 

    
    
    // Start is called before the first frame update
    void Start()
    {
       textBox = questionbox.GetComponentInChildren<Text>(); 
       textA = answerA.GetComponentInChildren<Text>(); 
       textB = answerB.GetComponentInChildren<Text>(); 
       
       initializeQuestions(); // must assign field values passed to Question() constructor before this call
       animator = this.GetComponent<Animator>();
       asm = GameObject.Find("AnswerSelectionManager").GetComponent<AnswerSelectionManager>();
       player = GameObject.FindWithTag("Player").GetComponent<Player>();  
       
       Question.correct = correct;
       Question.incorrect = incorrect; 
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public bool isSelecting() {
        return selecting;
    }
    


    /* Chooses a random Question from questions and asks it */ 
    public void AskQuestion() {
        if (questions.Count == 0) { initializeQuestions(); }    //if we are out of new questions, reinitialize
        currentQuestion = questions[(int) Mathf.Round(Random.Range(0, questions.Count))]; //chooses a random Question from the list
        currentQuestion.Ask(); 

        Invoke("ShowChoices", 1f); 
        Invoke("ShowResult", 10f); 

    }
    
    /* Calls ShowChoices() on the current question */ 
    private void ShowChoices() {
        selecting = true; 
        currentQuestion.ShowChoices();
    }
    
    /* Calls ShowAnswer() on the current question, and removes the current question from the list and from this class */ 
    private void ShowResult() {
        Invoke("finishQuestion", 5f); 
        selecting = false;
        LockInAnswer(); //determines which answer the player chose
        currentQuestion.ShowResult(playerAnswer);
        Invoke("TrickOrTreat", 2f); 
    }
    
    /* Locks in the player's current selection with AnswerSelectionManager as the answer */
    private void LockInAnswer() {
        if (asm.GetSelected() == AnswerSelectionManager.Selection.A) {
            playerAnswer = currentQuestion.getChoice().getChoiceA();  
        }
        else {
            playerAnswer = currentQuestion.getChoice().getChoiceB();
        }
    }
    
    private void finishQuestion() {
        currentQuestion.finish();
        questions.Remove(currentQuestion);
        animator.SetTrigger("DoneWithQuestion");
    }
    
    
    
    /* Depending on whether the player's answer was correct, give them a reward or
     * a punishment. */ 
    private void TrickOrTreat() {
        if (playerAnswer == currentQuestion.getCorrectAnswer()) {
            Treat(); 
        }
        else {
            Trick(); 
        }
    }
    
    private void Trick() {
        player.TakeDamage(3); 
    }
    
    /* Rewards the player with the SPECIAL weapon to hurt the boss */
    private void Treat() {
        GameObject temp = Instantiate(SpecialWeaponPickup, new Vector3(301.75f, 120.518f, 256.9f), new Quaternion()); 
    }
    
    
    
    /* Creates the Questions and adds them to questions */
    private void initializeQuestions() {
        questions = new List<Question>(); //empties the list
        
        //Add questions and answers to the Dictionary
        string quest = "Do you even have EXPERIENCE in this FIELD?";
        Answer ans = new Answer("Not much.", false); 
        Answer ans2 = new Answer("Not much, but I'm happy to learn.", true); 
        Choice c = new Choice(ans, ans2); 
        Question q = new Question(quest, c, questionbox, textBox, answerA, textA, answerB, textB); 
        questions.Add(q); 
        
        quest = "Have you used [extremely specific software]?";
        ans = new Answer("No.", false); 
        ans2 = new Answer("No, but I will learn it in my spare time before I get on the job, without asking for overtime pay!", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox, answerA, textA, answerB, textB); 
        questions.Add(q); 
        
        quest = "How do you deal with stressful situations?";
        ans = new Answer("Sometimes I panic and cry, but I know I will make it through.", false); 
        ans2 = new Answer("I keep a positive outlook (and hide my true feelings).", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox, answerA, textA, answerB, textB); 
        questions.Add(q); 
        
        quest = "Do you have experience working with others?";
        ans = new Answer("Of course, I collaborated for many school projects and in my previous internships.", true); 
        ans2 = new Answer("Yes, experiences I'd rather not repeat.", false); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox, answerA, textA, answerB, textB); 
        questions.Add(q); 
        
        quest = "How would you describe yourself?";
        ans = new Answer("Extremely hardworking. Have you seen my GPA?", false); 
        ans2 = new Answer("Hardworking, but also chill, like, you could grab a beer with me.", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox, answerA, textA, answerB, textB); 
        questions.Add(q); 
        
        quest = "Are you willing to travel up to 99% of the time?";
        ans = new Answer("...Umm...am I allowed to say 'no'?", false); 
        ans2 = new Answer("Of course!", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox, answerA, textA, answerB, textB); 
        questions.Add(q); 
    }
}
