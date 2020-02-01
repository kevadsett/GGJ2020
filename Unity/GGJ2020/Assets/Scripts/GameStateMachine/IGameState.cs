using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    GameStateMachine StateMachine { get; }
    void OnEnter();
    void Update();
    void OnExit();
}
