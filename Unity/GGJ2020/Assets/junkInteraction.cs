using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junkInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Transform displayPoint;

    public GameObject currentObj = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.tag == "Junk") {

            currentObj = other.gameObject;

            Instantiate(currentObj, this.transform);
            Destroy(other.gameObject);
        }
        
    }
}
