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
        this.gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
        this.gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 0f);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (! (anchor == null)) {
            Vector3 pos = Camera.main.WorldToScreenPoint(anchor.transform.position);
            //Debug.Log("pos: " + pos); 
            this.gameObject.GetComponent<RectTransform>().anchoredPosition3D = pos + offset; 
            //this.gameObject.SetActive(true); 
            //Debug.Log("The resulting position is literally " + this.gameObject.GetComponent<RectTransform>().position + " for " + this.gameObject.name);
            //Debug.Log("The resulting anchoredPosition is " + this.gameObject.GetComponent<RectTransform>().anchoredPosition + " for " + this.gameObject.name); 
            //Debug.Log("The resulting anchoredPosition3D is " + this.gameObject.GetComponent<RectTransform>().anchoredPosition3D + " for " + this.gameObject.name); 
        }
 
    }

}
