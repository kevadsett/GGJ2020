using UnityEngine;
using UnityEngine.SceneManagement;
public class RunningState : AbstractState
{
    public RunningState(GameStateMachine InStateMachine, GameObject InStateUI) : base(InStateMachine, InStateUI)
    {
    }

    override public void OnEnter()
    {
        base.OnEnter();
        SceneManager.LoadScene("Running", LoadSceneMode.Additive);
    }
}
