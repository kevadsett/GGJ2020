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
            if (currentObj != null) {
                
            GameObject oldJunk= Instantiate(currentObj, displayPoint.position, transform.rotation, this.transform);
                oldJunk.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 100f);
            }
            currentObj = other.gameObject;
            
            Instantiate(currentObj.transform.GetChild(0), displayPoint.position, transform.rotation,this.transform);

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }

    private void DetachJunk() {

    }
}
