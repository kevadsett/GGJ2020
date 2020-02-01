using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultsState : AbstractState
{
    public ResultsState(GameStateMachine InStateMachine, GameObject InStateUI) : base(InStateMachine, InStateUI)
    {
    }

    override public void OnExit()
    {
        base.OnExit();
        SceneManager.UnloadSceneAsync("Running");
    }
}
