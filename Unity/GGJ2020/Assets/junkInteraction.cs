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
            JunkBehaviour TheirJunk = other.GetComponent<JunkBehaviour>();
            if (TheirJunk.JunkState != JunkBehaviour.eJunkState.Idle)
            {
                break;
            }

            if (isCarrying)
            {
                dropJunk();
            }
            isCarrying = true;
            TheirJunk.PickUp();
            MyJunk.SetJunkType(TheirJunk.JunkType);
            CurrentInactiveJunk = other.gameObject;

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
            bool anyHit = false;

            var myCM = GetComponent<CharacterMovement>();
            var otherCM = col.gameObject.GetComponent<CharacterMovement>();

            Vector3 between = otherCM.transform.position - myCM.transform.position;

            bool amIDashing = myCM.State == CharacterMovement.eState.Dashing;

            if (otherCM.State == CharacterMovement.eState.Dashing)
            {
                if (Vector3.Dot (between, otherCM.MovementVector) <= 0f)
                {
                    anyHit = true;
                    myCM.SetStunned();
                    dropJunk();

                    CameraShake.Shake(col.gameObject.GetComponent<CharacterMovement>().MovementVector);
                }
            }

            if (amIDashing)
            {
                if (Vector3.Dot (between, myCM.MovementVector) >= 0f)
                {
                    anyHit = true;
                    otherCM.SetStunned();
                    otherCM.GetComponent<junkInteraction> ().dropJunk();
                }
            }

            if (anyHit) AudioPlayer.PlaySound ("SFX_Hit", transform.position);
        }
    }

    private void dropJunk() {
        if (isCarrying == false)
        {
            return;
        }
        isCarrying = false;
        MyJunk.gameObject.SetActive(false);

        if (CurrentInactiveJunk != null)
        {
            CurrentInactiveJunk.GetComponent<JunkBehaviour>().Drop(transform.position);
        }
    }
}
