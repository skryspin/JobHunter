using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity; 
    public int attack; 
    public bool destroyAfterTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Disappear", 4.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = this.transform.localPosition + velocity;
    }
    
    void Disappear() {
        if (destroyAfterTime) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) {
            other.GetComponent<Player>().TakeDamage(attack); 
            Destroy(this.gameObject);
        }
        
    }
}
