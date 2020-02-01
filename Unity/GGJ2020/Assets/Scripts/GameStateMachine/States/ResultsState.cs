public class ResultsState : IGameState
{
    public GameStateMachine StateMachine { get; private set; }

    public ResultsState(GameStateMachine InStateMachine)
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
