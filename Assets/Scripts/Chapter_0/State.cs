using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void Enter();
    void Stay();
    void Exit();
}
