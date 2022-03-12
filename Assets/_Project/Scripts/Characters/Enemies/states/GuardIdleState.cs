using UnityEngine;
using UnityEngine.AI;

public class GuardIdleState : MonoBehaviour, IState
{
    GuardStateMachine stateMachine;

    NavMeshAgent _agent;
    public void OnStateEntered()
    {
        stateMachine = GetComponent<GuardStateMachine>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.autoBraking = false;
        stateMachine._playerDetectionHandler += ChangeToAlertState;
    }

    public void OnStateExecute()
    {
        
    }

    void ChangeToAlertState()
    {
        stateMachine.ChangeState<GuardChaseState>();
    }

    public void OnStateExit()
    {
        _agent = null;
        stateMachine._playerDetectionHandler -= ChangeToAlertState;
    }
}