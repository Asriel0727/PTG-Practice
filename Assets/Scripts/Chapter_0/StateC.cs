using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateC : State
{
    public void Enter() { Debug.LogWarning("StateC Enter"); }
    public void Stay() { Debug.Log("StateC Stay"); }
    public void Exit() { Debug.LogError("StateC Exit"); }
}
