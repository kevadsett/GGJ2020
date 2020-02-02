using UnityEngine;
public class TitleState : AbstractState
{
    public TitleState (GameStateMachine InStateMachine, GameObject InStateUI) : base(InStateMachine, InStateUI)
    {
    }


    override public void OnEnter()
    {
        AudioPlayer.PlaySound ("Music_Menu");
        base.OnEnter ();
    }

    override public void Update()
    {
        if (Input.anyKeyDown)
        {
            StateMachine.ChangeState(eGameState.Running);
        }
    }
}
