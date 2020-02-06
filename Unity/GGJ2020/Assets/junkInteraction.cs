using UnityEngine;

[RequireComponent(typeof(PlayerId))]
public class junkInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    public JunkDisplay MyJunk;

    public bool isCarrying = false;

    private PlayerId MyId;

    public GameObject CurrentInactiveJunk;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyJunk.gameObject.SetActive(false);
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

            JunkBehaviour TheirJunk = other.GetComponent<JunkBehaviour>();
            if (TheirJunk.BeingCarried)
            {
                break;
            }
            isCarrying = true;
            TheirJunk.BeingCarried = true;
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

                CameraShake.Shake(col.gameObject.GetComponent<CharacterMovement>().MovementVector);
            }
        }
    }

    private void dropJunk() {
        if (isCarrying == false)
        {
            return;
        }
        Vector3 spawnPosition = new Vector3(MyJunk.transform.position.x, Random.value + MyJunk.transform.position.y - 1.6f, -5); //To spawn Detached-Objects in better place.
        if (CurrentInactiveJunk != null)
        {
            CurrentInactiveJunk.transform.position = spawnPosition;
            CurrentInactiveJunk.SetActive(true);
            CurrentInactiveJunk.GetComponent<JunkBehaviour>().BeingCarried = false;
        }
        isCarrying = false;
        MyJunk.gameObject.SetActive(isCarrying);

    }
}
