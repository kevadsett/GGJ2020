using UnityEngine;
public abstract class AbstractState : IGameState
{
    private GameStateMachine StateMachine;
    private GameObject StateUIPrefab;
    private GameObject StateUIInstance;
    public AbstractState(GameStateMachine InStateMachine, GameObject InStateUI)
    {
        StateMachine = InStateMachine;
        StateUIPrefab = InStateUI;
    }
    public void OnEnter()
    {
        StateUIInstance = GameObject.Instantiate(StateUIPrefab, StateMachine.UICanvas);
    }
    
    public void Update()
    {
        // override in concrete class
    }

    public void OnExit()
    {
        GameObject.Destroy(StateUIInstance);
    }
}
