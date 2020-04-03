using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Boss : MonoBehaviour
{

    List<Question> questions = new List<Question>(); 
    Question currentQuestion;
    Animator animator;
    public GameObject questionbox; 
    private Text textBox; //where the question text is displayed
    
    // Start is called before the first frame update
    void Start()
    {
       textBox = questionbox.GetComponentInChildren<Text>(); 
       initializeQuestions();
       animator = this.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Chooses a random Question from questions and asks it */ 
    public void AskQuestion() {
        if (questions.Count == 0) { initializeQuestions(); }    //if we are out of new questions, reinitialize
        currentQuestion = questions[(int) Mathf.Round(Random.Range(0, questions.Count))]; //chooses a random Question from the list
        currentQuestion.Ask(); 

        Invoke("ShowChoices", 1f); 
        Invoke("ShowAnswer", 10f); 

    }
    
    /* Calls ShowChoices() on the current question */ 
    private void ShowChoices() {
        currentQuestion.ShowChoices();
    }
    
    /* Calls ShowAnswer() on the current question, and removes the current question from the list and from this class */ 
    private void ShowAnswer() {
        Invoke("finishQuestion", 5f); 
        currentQuestion.ShowAnswer();
    }
    
    private void finishQuestion() {
        currentQuestion.finish();
        questions.Remove(currentQuestion);
        animator.SetTrigger("DoneWithQuestion");
    }
    
    
    /* Creates the Questions and adds them to questions */
    private void initializeQuestions() {
        questions = new List<Question>(); //empties the list
        
        //Add questions and answers to the Dictionary
        string quest = "Do you even have EXPERIENCE in this FIELD?";
        Answer ans = new Answer("Not much.", false); 
        Answer ans2 = new Answer("Not much, but I'm happy to learn.", true); 
        Choice c = new Choice(ans, ans2); 
        Question q = new Question(quest, c, questionbox, textBox); 
        questions.Add(q); 
        
        quest = "Have you used [extremely specific software]?";
        ans = new Answer("No.", false); 
        ans2 = new Answer("No, but I will learn it in my spare time before I get on the job, without asking for overtime pay!", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox); 
        questions.Add(q); 
        
        quest = "How do you deal with stressful situations?";
        ans = new Answer("Sometimes I panic and cry, but I know I will make it through.", false); 
        ans2 = new Answer("I keep a positive outlook (and hide my true feelings).", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox); 
        questions.Add(q); 
        
        quest = "Do you have experience working with others?";
        ans = new Answer("Of course, I collaborated for many school projects and in my previous internships.", true); 
        ans2 = new Answer("Yes, experiences I'd rather not repeat.", false); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox); 
        questions.Add(q); 
        
        quest = "How would you describe yourself?";
        ans = new Answer("Extremely hardworking. Have you seen my GPA?", false); 
        ans2 = new Answer("Hardworking, but also chill, like, you could grab a beer with me.", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox); 
        questions.Add(q); 
        
        quest = "Are you willing to travel up to 99% of the time?";
        ans = new Answer("...Umm...am I allowed to say 'no'?", false); 
        ans2 = new Answer("Of course!", true); 
        c = new Choice(ans, ans2); 
        q = new Question(quest, c, questionbox, textBox); 
        questions.Add(q); 
    }
}
