public class TitleState : IGameState
{
    public GameStateMachine StateMachine { get; private set; }
    public TitleState(GameStateMachine InStateMachine)
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
