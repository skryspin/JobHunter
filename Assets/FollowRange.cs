using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Attach with a collider. It enforces the follow range of a Security Guard enemy: the security guard
 * cannot follow the player if it leaves its range. */ 
public class FollowRange : MonoBehaviour
{
    public NavigableEnemy enemy; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy.target) {
            enemy.gameObject.GetComponent<Animator>().SetTrigger("LostTarget");
            Debug.Log("lost target");
        }
    }
}
