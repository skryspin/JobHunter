using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset; 
    [SerializeField] private GameObject target;
    public bool pointmode = false;
    private Vector3 rotOffset; 
    private Player player; 
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started camera");
        player = GameObject.FindWithTag("Player").GetComponent<Player>(); 
        this.gameObject.GetComponent<Animator>().enabled = false; 

    }

    // Update is called once per frame
    void Update()
    {
        if (pointmode) {
            this.transform.LookAt(target.transform);
        }
        else {
            Vector3 playerpos = player.transform.position;  //get player position
            this.transform.position = playerpos + offset;   //apply the offset
    
            this.transform.RotateAround(player.transform.position, player.transform.up, 200f * Input.GetAxis("RHorizontal") * Time.deltaTime); 
            this.transform.RotateAround(player.transform.position, player.transform.right, 100f * Input.GetAxis("RVertical") * Time.deltaTime); 
    
            Debug.Log("RHorizontal: " + Input.GetAxis("RHorizontal"));
                    Debug.Log("RVertical: " + Input.GetAxis("RVertical"));
    
            this.transform.LookAt(player.transform); 
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles + rotOffset); 
    
            offset = this.transform.position - playerpos;
        }


    }
}
