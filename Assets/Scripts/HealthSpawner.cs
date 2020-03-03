using UnityEngine;
using System.Collections;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthdrop;
    
    // Use this for initialization
    void Start()
    {
        Invoke("SpawnHealth", 0);
        Invoke("SpawnHealth", 1);
        Invoke("SpawnHealth", 2); 
        Invoke("DestroySelf", 2.1f); 
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /* Spawns a healthdrop at this location + a random offset*/ 
    private void SpawnHealth() {
        Vector3 spawnOffset = new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f), Random.Range(-2f, 2f)); 
        Instantiate(healthdrop, this.transform.position + spawnOffset, this.transform.rotation); 
    }
    
    void DestroySelf() {
        Destroy(this.gameObject); 
    }
}
