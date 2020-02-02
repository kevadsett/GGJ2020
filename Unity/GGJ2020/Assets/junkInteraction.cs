using UnityEngine;

[RequireComponent(typeof(PlayerId))]
public class junkInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    public JunkBehaviour MyJunk;

    public bool isCarrying = false;

    private PlayerId MyId;

    public GameObject CurrentInactiveJunk;

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
                    dropJunk();
               
            }
            isCarrying = true;
            JunkBehaviour TheirJunk = other.GetComponent<JunkBehaviour>();
            MyJunk.SetJunkType(TheirJunk.JunkType);
            CurrentInactiveJunk = other.gameObject;
            CurrentInactiveJunk.SetActive(false);

            AudioPlayer.PlaySound ("SFX_Pickup", transform.position);

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
                AudioPlayer.PlaySound ("SFX_Repair", transform.position);
            }
            break;
        }
        MyJunk.gameObject.SetActive(isCarrying);
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" )
        {
            if (col.gameObject.GetComponent<CharacterMovement>().State == CharacterMovement.eState.Dashing)
            {
                AudioPlayer.PlaySound ("SFX_Hit", transform.position);
                GetComponent<CharacterMovement>().SetStunned();
                dropJunk();
            }
        }
    }

    private void dropJunk() {
        Vector3 spawnPosition = new Vector3(MyJunk.transform.position.x, Random.value + MyJunk.transform.position.y - 1.6f, MyJunk.transform.position.z); //To spawn Detached-Objects in better place.
        if (CurrentInactiveJunk != null)
        {
            CurrentInactiveJunk.transform.position = spawnPosition;
            CurrentInactiveJunk.SetActive(true);
        }
        isCarrying = false;
        MyJunk.gameObject.SetActive(isCarrying);

    }
}
