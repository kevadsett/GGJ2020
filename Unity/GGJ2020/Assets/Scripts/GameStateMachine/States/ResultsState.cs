using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsState : AbstractState
{
    public static float ResultDelay = 0.5f;
    private float StateTimer;
    public ResultsState(GameStateMachine InStateMachine, GameObject InStateUI) : base(InStateMachine, InStateUI)
    {
    }

    override public void OnEnter()
    {
        base.OnEnter();
        StateTimer = 0;
        SceneManager.LoadScene("Results", LoadSceneMode.Additive);
    }

    override public void Update()
    {
        StateTimer += Time.deltaTime;
        if (StateTimer < ResultDelay)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            StateMachine.ChangeState(eGameState.Running);
        }
    }

    override public void OnExit()
    {
        base.OnExit();
        SceneManager.UnloadSceneAsync("Results");
    }
}
