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

        AudioPlayer.StopSound ("Music_Menu");
        AudioPlayer.PlaySound ("Music_Gameplay");
    }

    override public void OnExit()
    {
        base.OnExit();
        PointsSystem.PlayerWinEvent.RemoveListener(OnPlayerWin);
        SceneManager.UnloadSceneAsync("Running");
    }

    private void OnPlayerWin()
    {
        AudioPlayer.StopSound ("Music_Gameplay");
        AudioPlayer.PlaySound ("Music_VictoryStinger");

        StateMachine.ChangeState(eGameState.Results);
    }
}
