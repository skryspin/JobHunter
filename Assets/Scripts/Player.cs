using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System; 

public class Player : MonoBehaviour
{

    //Movement (private)
    private CharacterController characterController;
    private GameObject my_camera;
    private Vector3 lastMovement;
    private Vector3 lastMovementDirection;
    private int score;
    
    /* Jump Buffering
     * These variables are used to allow the player to jump slightly late or slightly early;
     * as in, if they hit jump within BUFFER frames of being on the ground (Early or late), 
     * then they will jump. Of course, due to the rules of time, if they hit the jump late,
     * they will jump slightly late, but this is better than the jump not registering at all.
     * In contrast, if they jump early, the jump will not register until they actually hit the
     * ground, to prevent them from jumping higher than normal. Also, we need to do that because
     * we cannot /predict/ if a player will in the ground; we simply wait and see if it happens.
     * */ 
    private const int BUFFER = 6; 
    private int framesRemainingForStoredJump; //stores how many frames until a stored jump is disregarded
    private bool storedJump; // did the player hit jump within the past BUFFER frames?
    private bool storedGround; // was the player on the ground in the last BUFFER frames?
    private int framesRemainingForStoredGround; //stores how many frames until a stored ground in disregarded 
    


    //Movement (public)
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float pushPower;
    public string mode; 

    //Combat
    public int currentHealth;
    public int maxHealth;
    public Slider healthBar;
    
    //Resume Throw
    public GameObject resumePrefab; 
    
    //Death
    private bool dieOnNextUpdate = false; 


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Testing...");
        characterController = this.GetComponent<CharacterController>();
        my_camera = GameObject.FindWithTag("MainCamera");
        if (resumePrefab == null) {
            Debug.LogError("No resume prefab assigned to Player of name" + gameObject.name); 
        }
        mode = "Keyboard";
        //pushPower = 25.0f;

    }

    // Update is called once per frame
    void Update()
    {
        jumpBuffer(); // handles jump buffering for EARLY jump commands
        toggleMode(); 
        doMovement();
        if ((currentHealth == 0) || (dieOnNextUpdate)) {
            GameOver();
            dieOnNextUpdate = false ;
        }
        turnToMovement(); 
        doResumeThrow();
        
    }
    

    private void FixedUpdate()
    {

    }
    
    private void jumpBuffer() {
    
        earlyJumpBuffer(); 
        //if (Input.GetKey(KeyCode.B)) {
        lateJumpBuffer(); 
        //}
        
        
        /*Handles an EARLY jump*/
        void earlyJumpBuffer() {
            if (Input.GetButtonDown("Jump")) { //only store the jump on Button Down 
                                               // - otherwise, player could hold down jump to jump every time they hit the ground!
                storedJump = true; 
                Debug.Log("Storing jump with BUFFER = " + BUFFER); 
                framesRemainingForStoredJump = BUFFER; //set frames since stored Jump to the max
            }
            else {
                if (framesRemainingForStoredJump > 0) {
                    framesRemainingForStoredJump--; //decrement
                    Debug.Log("framesRemainingForStoredJump: " + framesRemainingForStoredJump); 
                    if (framesRemainingForStoredJump == 0) {
                        storedJump = false; 
                    } 
                }
                
            }
        }
        
       /*Handles a LATE jump*/
        void lateJumpBuffer() {
            if(characterController.isGrounded) {
                storedGround = true; 
                Debug.Log("Storing ground with BUFFER = " + BUFFER);
                framesRemainingForStoredGround = BUFFER; 
            } 
            else {
                if (framesRemainingForStoredGround > 0) {
                    framesRemainingForStoredGround--; 
                    Debug.Log("framesRemainingForStoredGround: " + framesRemainingForStoredGround);
                    if (framesRemainingForStoredGround == 0) {
                        storedGround = false; 
                    }
                }
            
            }
        } 
    } 
    
    
    
    public void doResumeThrow() {
        if (Input.GetButtonDown("Throw")) {
            Resume resume = Instantiate(resumePrefab, this.transform.position, new Quaternion()).GetComponent<Resume>();
            resume.SetDirection(lastMovementDirection, this.transform);  
            Debug.DrawRay(transform.position, lastMovementDirection, Color.cyan); 
       }
    }

    /* Applies dmg points of damage to the player's health, and 
     * returns current health of player, between 0 and maxHealth */
    public int TakeDamage(int dmg)
    {
        if (dmg < 0)
        {
            Debug.Log("Error: Incorrect damage value given!");
            return -1;
        }
        if ((currentHealth - dmg) < 0)
        {
            currentHealth = 0;
            Debug.Log("You took " + dmg + " damage.");
            Debug.Log("Current health: " + currentHealth);
            return 0;
        }
        else
        {
            currentHealth = currentHealth - dmg;
            Debug.Log("You took " + dmg + " damage.");
            Debug.Log("Current health: " + currentHealth);
            return currentHealth;
        }

    }
    
    private int normalizeInput(float inputValue) {
        if (inputValue > 0) {
            inputValue = 1;
        }
        else if (inputValue < 0) {
            inputValue = -1;
        }
        else {
            inputValue = 0;
        }
        return (int) inputValue;
    }
    
    private float getVerticalInput() {
        if (mode == "Keyboard") {
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) 
                return 0; 
            else if (Input.GetKey(KeyCode.UpArrow)) {
                return 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow)) {
                return -1;
            }
            else {
                return 0;
            }
        }
        else if (mode == "Joycon") {
            float rawVerticalInput = Input.GetAxis("Vertical");
            Debug.Log("Vertical: " + rawVerticalInput);
            float verticalInput = rawVerticalInput; // normalizeInput(rawVerticalInput);
            Debug.Log("Vertical: " + verticalInput);
            return verticalInput; 
        }
        else {
            Debug.LogError("Invalid control mode"); 
            return 0; 
         }
    
    }
    
    private float getHorizontalInput() {
        if (mode == "Keyboard") {
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)) 
                return 0; 
            else if (Input.GetKey(KeyCode.RightArrow)) {
                return 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) {
                return -1;
            }
            else {
                return 0;
            }
        }
        else if (mode == "Joycon") {
            float rawHorizontalInput = Input.GetAxis("Horizontal");
           // Debug.Log("RawHorizontal: " + rawHorizontalInput);
            float horizontalInput = rawHorizontalInput; // normalizeInput(rawHorizontalInput);
           // Debug.Log("NormHorizontal: " + horizontalInput);
            return horizontalInput; 
        }
        else {
            Debug.LogError("Invalid control mode"); 
            return 0; 
         }
    
    }
    
    private bool toggleMode() {
       // Debug.Log("Inside toggle mode.");
       // Debug.Log(Input.GetAxis("Horizontal")); 
        if ((mode == "Keyboard") && (Input.GetAxis("Horizontal") != 0)) {
            mode = "Joycon";
           // Debug.Log("Joycon mode..."); 
            return true; 
        }
        else if ((mode == "Joycon") && ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) ) {
            mode = "Keyboard";
          //  Debug.Log("Keyboard mode..."); 

            return true; 
        }
        return false; 
    
    
    }

    /* Does the player movement, and updates lastMovementDirection .*/ 
    private void doMovement()
    {

        float verticalInput = getVerticalInput();
        float horizontalInput = getHorizontalInput();

        Vector3 up_direction = Vector3.Normalize(new Vector3(my_camera.transform.forward.x, 0, my_camera.transform.forward.z));
        //Debug.DrawRay(this.transform.position, Vector3.Normalize(up_direction)*3, Color.blue); 
        //Debug.Log("Up magnitude" + up_direction.magnitude); 
        Vector3 right_direction = Vector3.Normalize(new Vector3(my_camera.transform.right.x, 0, my_camera.transform.right.z));
        //Debug.DrawRay(this.transform.position, Vector3.Normalize(right_direction)*3, Color.red); 
        //Debug.Log("Right magnitude" + right_direction.magnitude); 
        
        

        Vector3 movement = up_direction * verticalInput + right_direction * horizontalInput;
        //lastMovementDirection = movement; 


        
        if (movement.magnitude != 0) {
            lastMovementDirection = movement; 
            Debug.DrawRay(this.transform.position, movement*3, Color.red); 

        }
        
        movement *= speed;

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump") || (storedJump && Input.GetButton("Jump")) )
            {
                //Debug.Log("jump detected!");
                movement.y = jumpSpeed;
                storedJump = false; 
                storedGround = false; 
            }
        }
        else if (storedGround && Input.GetButton("Jump")) {
            movement.y = jumpSpeed; 
            storedJump = false; 
            storedGround = false; 
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (lastMovement.y > 0)
            { //this is important - we don't want the velocity reset to 0 if he is already falling!
                movement.y = 0;
                //Debug.Log("STOP");
            }
            else
            {
                movement.y = lastMovement.y;
            }
        }
        else
        {
            movement.y = lastMovement.y;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        movement.y -= gravity * Time.deltaTime;
        //Debug.Log(movement.y);




        characterController.Move(movement * Time.deltaTime);
        lastMovement = movement;
       // Debug.DrawRay(transform.position, lastMovement, Color.blue);

        
    }
    
    /* Rotates the player to face the movement direction */
    public void turnToMovement() {
        transform.LookAt(transform.position + lastMovementDirection);

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject cuddleBuddy = other.gameObject;
        //Debug.Log("Collision detected with: " + cuddleBuddy);


        if (cuddleBuddy.CompareTag("Collectable"))
        {
            Destroy(cuddleBuddy);
            score++;
            //Debug.Log(score);
        }
        else if (cuddleBuddy.CompareTag("InstaDeath")) {
           dieOnNextUpdate = true;  
        }
        
        
    }


    // this script pushes all rigidbodies that the character touches    
    /* Function adapted from Unity documentation */
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        //// We dont want to push objects below us
        //if (hit.moveDirection.y < -0.3)
        //{
        //    return;
        //}

        // Calculate push direction from move direction,
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.AddForce(pushDir * pushPower);
    }
    
    private void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload the current scene
        // you should probably change this to reset the player to the last spawn point
        // maybe spawn points save the player's state? and then you return to that state if you die.
        
    
    
    }
}
