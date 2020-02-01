using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    void OnEnter();
    void Update();
    void OnExit();
}
