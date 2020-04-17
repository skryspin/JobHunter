using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialResume : Resume
{
    // Damage for this is set in the prefab's ResumeCollider 
    
    
    protected static Color[] colors = { Color.red, Color.red*1.5f +  Color.yellow, Color.yellow, Color.green, Color.blue, Color.magenta };
    protected static int current_color = 0; 
    
    // Start is called before the first frame update
    protected override void Start()
    { 
        div = 3;
        this.gameObject.GetComponentInChildren<Renderer>().material.color = colors[current_color]; 
        current_color++; 
        if (current_color >= colors.Length) {
            current_color = 0;
        } 
    }

    protected override void Update()
    {
        base.Update();
        transform.Rotate(new Vector3(90, 0, 0));
        
    }

}
