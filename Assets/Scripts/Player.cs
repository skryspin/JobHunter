using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //Movement (private)
    private CharacterController characterController;
    private GameObject my_camera;
    private Vector3 lastMovement;
    private int score;


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
    public Button btn;
    
    //Death
    private bool dieOnNextUpdate = false; 


    // Start is called before the first frame update
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        my_camera = GameObject.FindWithTag("MainCamera");
        btn.onClick.AddListener(() => TakeDamage(1));
        //pushPower = 25.0f;

    }

    // Update is called once per frame
    /* Note: Much of this code was referenced from the Unity manual */
    void Update()
    {
        doMovement();
        if ((currentHealth == 0) || (dieOnNextUpdate)) {
            GameOver();
            dieOnNextUpdate = false ;
        }
        
    }
    

    private void FixedUpdate()
    {

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
    
    private int getVerticalInput() {
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
            int verticalInput = normalizeInput(rawVerticalInput);
            Debug.Log("Vertical: " + verticalInput);
            return verticalInput; 
        }
        else {
            Debug.LogError("Invalid control mode"); 
            return 0; 
         }
    
    }
    
    private int getHorizontalInput() {
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
            Debug.Log("Horizontal: " + rawHorizontalInput);
            int horizontalInput = normalizeInput(rawHorizontalInput);
            Debug.Log("Horizontal: " + horizontalInput);
            return horizontalInput; 
        }
        else {
            Debug.LogError("Invalid control mode"); 
            return 0; 
         }
    
    }

    private void doMovement()
    {

        int verticalInput = getVerticalInput();
        int horizontalInput = getHorizontalInput();

        Vector3 up_direction = new Vector3(my_camera.transform.forward.x, 0, my_camera.transform.forward.z);
        Vector3 right_direction = new Vector3(my_camera.transform.right.x, 0, my_camera.transform.right.z);

        Vector3 movement = up_direction * verticalInput + right_direction * horizontalInput;
        movement *= speed;

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log("jump detected!");
                movement.y = jumpSpeed;
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (lastMovement.y > 0)
            { //this is important - we don't want the velocity reset to 0 if he is already falling!
                movement.y = 0;
                Debug.Log("STOP");
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

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject cuddleBuddy = other.gameObject;
        Debug.Log("Collision detected with: " + cuddleBuddy);


        if (cuddleBuddy.CompareTag("Collectable"))
        {
            Destroy(cuddleBuddy);
            score++;
            Debug.Log(score);
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
