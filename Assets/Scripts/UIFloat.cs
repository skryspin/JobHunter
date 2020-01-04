using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFloat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject anchor; 
    public Vector3 offset; 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anchor != null) {
            Vector3 pos = Camera.main.WorldToScreenPoint(anchor.transform.position);
            this.gameObject.GetComponent<RectTransform>().position = pos + offset; 
        }
    }
}
