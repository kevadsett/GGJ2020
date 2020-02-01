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
           if(isCarrying == false)
            {
            isCarrying = true;
            currentObj.SetActive(isCarrying);

            }
            
           // currentObj.GetComponent<JunkBehaviour>().JunkType = 
          
          //  currentObj.transform.GetChild(0).GetComponent<JunkBehaviour>().SetJunkType= other.gameObject.GetComponent<JunkBehaviour>().JunkType;

            Destroy(other.gameObject);
        }
        
    }
}
