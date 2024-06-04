using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateB : State
{
    public void Enter() { Debug.LogWarning("StateB Enter"); }
    public void Stay() { Debug.Log("StateB Stay"); }
    public void Exit() { Debug.LogError("StateB Exit"); }
}
