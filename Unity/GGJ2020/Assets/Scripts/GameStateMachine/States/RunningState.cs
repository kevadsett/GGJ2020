public class RunningState : IGameState
{
    public GameStateMachine StateMachine { get; private set; }

    public RunningState(GameStateMachine InStateMachine)
    {
        StateMachine = InStateMachine;
    }
    public void OnEnter()
    {

    }
    
    public void Update()
    {
        
    }

    public void OnExit()
    {
        
    }
}
