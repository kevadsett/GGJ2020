using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junkInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    public GameObject currentObj;

    public bool isCarrying = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.tag == "Junk") {
           
            isCarrying = true;
            currentObj.SetActive(isCarrying);
            currentObj.GetComponent<JunkBehaviour>().SetJunkType(other.GetComponent<JunkBehaviour>().JunkType);
          Debug.Log("currentObject type: " + currentObj.GetComponent<JunkBehaviour>().JunkType + " other: " + other.GetComponent<JunkBehaviour>().JunkType);
            
            Destroy(other.gameObject);
        }
        
    }
}
