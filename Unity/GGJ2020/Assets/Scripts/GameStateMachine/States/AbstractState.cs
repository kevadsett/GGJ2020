using UnityEngine;
public abstract class AbstractState : IGameState
{
    protected GameStateMachine StateMachine;
    private GameObject StateUIPrefab;
    private GameObject StateUIInstance;
    public AbstractState(GameStateMachine InStateMachine, GameObject InStateUI)
    {
        StateMachine = InStateMachine;
        StateUIPrefab = InStateUI;
    }
    virtual public void OnEnter()
    {
        StateUIInstance = GameObject.Instantiate(StateUIPrefab, StateMachine.UICanvas);
    }

    virtual public void Update()
    {
        // override in concrete class
    }

    virtual public void OnExit()
    {
        GameObject.Destroy(StateUIInstance);
    }
}
