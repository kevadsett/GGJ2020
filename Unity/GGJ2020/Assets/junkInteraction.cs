using UnityEngine;

[RequireComponent(typeof(PlayerId))]
public class junkInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    public JunkBehaviour MyJunk;

    public bool isCarrying = false;

    private PlayerId MyId;

    private GameObject CurrentInactiveJunk;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyJunk.gameObject.SetActive(false);
        MyJunk.GetComponent<Rigidbody2D>().Sleep();
        MyId = GetComponent<PlayerId>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
        case "Junk":
            if (isCarrying)
            {
                CurrentInactiveJunk.transform.position = MyJunk.transform.position;
                CurrentInactiveJunk.SetActive(true);
            }
            isCarrying = true;
            JunkBehaviour TheirJunk = other.GetComponent<JunkBehaviour>();
            MyJunk.SetJunkType(TheirJunk.JunkType);
            CurrentInactiveJunk = other.gameObject;
            CurrentInactiveJunk.SetActive(false);
            break;
        case "JunkMachine":
            if (isCarrying == false)
            {
                break;
            }
            JunkMachine JunkMachine = other.GetComponent<JunkMachine>();
            if (JunkMachine.TrySlotJunk(MyJunk.JunkType, MyId.Id))
            {
                isCarrying = false;
            }
            break;
        }
        MyJunk.gameObject.SetActive(isCarrying);
        
    }
}
