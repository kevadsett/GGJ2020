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

        GameObject.FindObjectsOfType<PointsSystem>()[0].Reset();

        PointsSystem.PlayerWinEvent.AddListener(OnPlayerWin);
    }

    override public void OnExit()
    {
        base.OnExit();
        SceneManager.UnloadSceneAsync("Running");
    }

    private void OnPlayerWin()
    {
        StateMachine.ChangeState(eGameState.Results);
    }
}
