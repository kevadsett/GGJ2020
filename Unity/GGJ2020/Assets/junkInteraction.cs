using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junkInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Transform point;

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
            Destroy(other.gameObject);
            Instantiate(currentObj.transform.GetChild(0), point.position, transform.rotation,this.transform);

        }
    }
}
