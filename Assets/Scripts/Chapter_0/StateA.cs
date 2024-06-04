using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateA : State
{
    public void Enter() { Debug.LogWarning("StateA Enter"); }
    public void Stay() { Debug.Log("StateA Stay"); }
    public void Exit() { Debug.LogError("StateA Exit"); }
}
