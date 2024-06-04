using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    private StateMachine _stateMachine;
    private StateA _stateA;
    private StateB _stateB;
    private StateC _stateC;

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateA = new StateA();
        _stateB = new StateB();
        _stateC = new StateC();

        _stateMachine.ChangeState(_stateA);
    }

    private void Update()
    {
        _stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.B))
        {
            _stateMachine.ChangeState(_stateB);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _stateMachine.ChangeState(_stateC);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _stateMachine.ChangeState(_stateA);
        }
    }
}
