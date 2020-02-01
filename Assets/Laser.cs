using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int count; //tracking amount of times to shoot the laser
    
    public int numberOfShotsInCycle; 
    public float timeBetweenShotsInCycle;
    public float timeBetweenCycles;
    
    public GameObject projectile; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartLaunchCycle", 1.0f, timeBetweenCycles);

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void StartLaunchCycle() {
        count = numberOfShotsInCycle; 
        InvokeRepeating("LaunchProjectile", 0.0f, timeBetweenShotsInCycle);
        Debug.Log("Starting launch cycle");
    }
    
    public void LaunchProjectile() {
        count--; 
        if (count >= 0) {
            GameObject shot = GameObject.Instantiate(projectile, this.transform);
            shot.GetComponent<Bullet>().destroyAfterTime = true; 
            shot.transform.localPosition = new Vector3(0f, 0f, 0f); 
            //shot.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
            Debug.Log("Instantiating Laser Projectile at " + shot.transform.position);
        }
        else {
            CancelInvoke("LaunchProjectile");
        }
    }
}
