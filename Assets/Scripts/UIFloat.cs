using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFloat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go; 
    public Vector3 offset; 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go != null) {
            Vector3 pos = Camera.main.WorldToScreenPoint(go.transform.position);
            this.gameObject.GetComponent<RectTransform>().position = pos + offset; 
        }
    }
}
