using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameState
{
    Title,
    Running,
    Results
}
public class GameStateMachine : MonoBehaviour
{
    public Transform UICanvas;
    public GameObject TitleStateUIPrefab;
    public GameObject RunningStateUIPrefab;
    public GameObject ResultsStateUIPrefab;
    public eGameState DefaultState = eGameState.Title;
    private Dictionary<eGameState, IGameState> StateMap;
    private IGameState CurrentState;

    void Start()
    {
        StateMap = new Dictionary<eGameState, IGameState>
        {
            { eGameState.Title, new TitleState(this, TitleStateUIPrefab) },
            { eGameState.Running, new RunningState(this, RunningStateUIPrefab) },
            { eGameState.Results, new ResultsState(this, ResultsStateUIPrefab) },
        };

        ChangeState(DefaultState);
    }

    void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
    
    public void ChangeState(eGameState NewState)
    {
        //Debug.Log("Changing state from " + (CurrentState == null ? "no state" : CurrentState.ToString()) + " to " + NewState.ToString());
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = StateMap[NewState];
        CurrentState.OnEnter();
    }
}
