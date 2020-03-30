using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour
{

    Dictionary<string, Choice> questions = new Dictionary<string, Choice>(); 
    // Start is called before the first frame update
    void Start()
    {
        //Add questions and answers to the Dictionary
        string quest = "Do you even have EXPERIENCE in this FIELD?";
        Answer ans = new Answer("Not much.", false); 
        Answer ans2 = new Answer("Not much, but I'm happy to learn.", true); 
        Choice c = new Choice(ans, ans2); 
        questions.Add(quest, c); 
        Choice output; 
        questions.TryGetValue(quest, out output); 
        Debug.Log(output.getCorrect().getText()); 
        
        quest = "Have you used [extremely specific software]?";
        ans = new Answer("No.", false); 
        ans2 = new Answer("No, but I will learn it in my spare time before I get on the job, without asking for overtime pay!", true); 
        c = new Choice(ans, ans2); 
        questions.Add(quest, c); 
        questions.TryGetValue(quest, out output); 
        Debug.Log(output.getCorrect().getText()); 
        
        quest = "How do you deal with stressful situations?";
        ans = new Answer("Sometimes I panic and cry, but I know I will make it through.", false); 
        ans2 = new Answer("I keep a positive outlook (and hide my true feelings).", true); 
        c = new Choice(ans, ans2); 
        questions.Add(quest, c); 
        questions.TryGetValue(quest, out output); 
        Debug.Log(output.getCorrect().getText()); 
        
        quest = "Do you have experience working with others?";
        ans = new Answer("Of course, I collaborated for many school projects and in my previous internships.", true); 
        ans2 = new Answer("Yes, experiences I'd rather not repeat.", false); 
        c = new Choice(ans, ans2); 
        questions.Add(quest, c); 
        questions.TryGetValue(quest, out output); 
        Debug.Log(output.getCorrect().getText()); 
        
        quest = "How would you describe yourself?";
        ans = new Answer("Extremely hardworking. Have you seen my GPA?", false); 
        ans2 = new Answer("Hardworking, but also chill, like, you could grab a beer with me.", true); 
        c = new Choice(ans, ans2); 
        questions.Add(quest, c); 
        questions.TryGetValue(quest, out output); 
        Debug.Log(output.getCorrect().getText()); 
        
        quest = "Are you willing to travel up to 99% of the time?";
        ans = new Answer("...Umm...am I allowed to say 'no'?", false); 
        ans2 = new Answer("Of course!", true); 
        c = new Choice(ans, ans2); 
        questions.Add(quest, c); 
        questions.TryGetValue(quest, out output); 
        Debug.Log(output.getCorrect().getText()); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test"); 
    }
    
    public void AskQuestion() {
        List<string> temp = new List<string>(questions.Keys);   //gets list of all questions
        string key = temp[(int) Mathf.Round(Random.Range(0, temp.Count))]; //chooses a random key from the dictionary
        //Ask(key); // NOTE: implement. ask that question
        //TODO: Change from dictionary to list of Question objects that contains string question and Choice objects
    

    }
}
