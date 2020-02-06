using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    public eJunkType JunkType { get; private set; }
    public JunkDisplay MyJunkSlotDisplay;

    public AnimationCurve DropBounceAnim;
    public float DropDistance;
    public float DropDuration;
    public enum eJunkState
    {
        Idle,
        Carried,
        Dropped
    }
    public eJunkState JunkState { get; private set; }
    public Color UnpickupableColor;

    [SerializeField]
    private SpriteRenderer MySpriteRenderer;

    private Vector2 DroppedStartPosition;
    private Vector2 DroppedTargetPosition;

    private float DropTimer;

    void Start()
    {
        MyJunkSlotDisplay.SetJunkType(JunkType);
    }

    private void Update()
    {
        switch (JunkState)
        {
        case eJunkState.Dropped:
            DropTimer += Time.deltaTime;
            float newX = DropTimer / DropDuration * (DroppedTargetPosition.x - DroppedStartPosition.x) + DroppedStartPosition.x;
            float newY = DropTimer / DropDuration * (DroppedTargetPosition.y - DroppedStartPosition.y) + DroppedStartPosition.y + DropBounceAnim.Evaluate(DropTimer / DropDuration);
            transform.position = new Vector2(newX, newY);
            if (DropTimer >= DropDuration)
            {
                JunkState = eJunkState.Idle;
                MySpriteRenderer.color = Color.white;
            }
            break;
        }
    }

    public void SetJunkType(eJunkType NewType)
    {
        JunkType = NewType;
        if (MyJunkSlotDisplay)
        {
            MyJunkSlotDisplay.SetJunkType(JunkType);
        }
    }

    public void PickUp()
    {
        JunkState = eJunkState.Carried;
        gameObject.SetActive(false);
    }

    public void Drop(Vector2 DroppedPosition)
    {
        MySpriteRenderer.color = UnpickupableColor;
        DropTimer = 0;
        gameObject.SetActive(true);
        DroppedStartPosition = DroppedPosition;

        Vector2 DropDirection = new Vector2((Random.value * 2f - 1), (Random.value * 2f - 1)).normalized;

        DroppedTargetPosition = DroppedStartPosition + DropDirection * DropDistance;
        JunkState = eJunkState.Dropped;
    }
}
