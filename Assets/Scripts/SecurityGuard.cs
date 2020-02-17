using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class SecurityGuard : NavigableEnemy
{
    // Use this for initialization
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        if(dieOnNextFrame) {
            Destroy(this.gameObject); 
        } 
    }

    public override void takeDamage(int x)
    {
        base.takeDamage(x);
        this.anim.SetTrigger("SawPlayer");
    }
}
