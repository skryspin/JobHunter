using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset; 
    [SerializeField] private GameObject target;
    public bool pointmode = false;
    private Player player;     

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>(); 
        this.gameObject.GetComponent<Animator>().enabled = false; 

    }
    

    /* We manage camera in LateUpdate to ensure it is after the player's position is updated
     This prevents jitter */
    void LateUpdate()
    {
        if (pointmode) {
            this.transform.LookAt(target.transform);
        }
        else {
            Vector3 playerpos = player.transform.position;
            this.transform.position = playerpos + offset;   //apply the offset
    
            doVertRot(); 
            doHorizRot(); 
            
            this.transform.LookAt(player.transform); 
            offset = this.transform.position - playerpos;   //save the new offset
        }

    }
    
    /* Sets the position and rotation of of to to. */ 
    private void SetPosRot(Transform of, Transform to ) {
        of.position = to.position; 
        of.rotation = to.rotation;  
    }
    
    /* Calculates and applies the horizontal rotation of the camera */ 
    private void doHorizRot() {
        this.transform.RotateAround(player.transform.position, player.transform.up, 200f * Input.GetAxis("RHorizontal") * Time.deltaTime);

    }
    
    /* Calculates and applies the vertical rotation of the camera */ 
    private void doVertRot() {
            GameObject dummy = new GameObject(); //dummy object stores pos & rot before vertical rotation
            SetPosRot(dummy.transform, this.transform);  
            
            this.transform.RotateAround(player.transform.position, this.transform.right, 100f * Input.GetAxis("RVertical") * Time.deltaTime); 
            
            if (this.transform.rotation.eulerAngles.x > 75f && this.transform.rotation.eulerAngles.x < 285f) {  
                SetPosRot(this.transform, dummy.transform); //cancels rotation if it would move over or underneath the player
            }
            GameObject.Destroy(dummy); //destroy uneeded dummy object 
    }
}
